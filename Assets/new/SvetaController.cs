using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SvetaController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpVel = 22f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator an;

    public float hp = 100;
    public Image hpBar;

    public GameObject blade;
    public GameObject EnotWinsBanner;
    public GameObject Enot;

    private EnotController EnotCtrl;

    private Dictionary<string, bool> collision = new Dictionary<string, bool>();

    private List<GameObject> colliding = new List<GameObject>();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        an = GetComponent<Animator>();

        EnotCtrl = Enot.GetComponent<EnotController>();
    }
    
    void Update() {
        Move();

        if (hp <= 0) {
            EnotWinsBanner.SetActive(true);
            Invoke("endGame", 5);
        }
        hpBar.fillAmount = hp / 100;
    }

    void endGame() {
        SceneManager.LoadSceneAsync(1);
    }

    void Move() {
        if (collision["ground"]) {
            // an.SetBool("air", false);
            if (Input.GetKey(KeyCode.UpArrow)) {
                // an.SetBool("air", true);
                rb.velocity = Vector2.up * jumpVel;
            }
        }
        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            x = -1;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            x = 1;
        }

        float moveBy = x * speed;
        if (moveBy != 0) {
            an.SetBool("walking",true);
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        } else {
            an.SetBool("walking",false);
        }

        if (Input.GetKeyDown("[1]")) {
            an.SetBool("punch", true);
        } else {
            an.SetBool("punch", false);
        }
        if (Input.GetKey("[2]")) {
            an.SetBool("kick", true);
        } else {
            an.SetBool("kick", false);
        }
        // if (Input.GetKey("[3]")) {
        //     an.SetBool("throw", true);
        // } else {
        //     an.SetBool("throw", false);
        // }
    }

    void Throw() {
        Instantiate(blade, this.transform, false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collision[other.gameObject.tag] = true;   
    }

    private void OnCollisionExit2D(Collision2D other) {
        collision[other.gameObject.tag] = false;
    }

    public void Punch() {
        Debug.Log("PUNCH START");
        float dist = Vector3.Distance(Enot.transform.position, transform.position);
        Debug.Log("PUNCH dist: " + dist);
        if (dist < 5f) {
            EnotCtrl.hp-=10;
        }
        Debug.Log("PUNCH END");
    }

    public void Kick() {
        Debug.Log("KICK START");
        float dist = Vector3.Distance(Enot.transform.position, transform.position);
        Debug.Log("KICK dist: " + dist);
        if (dist < 5f) {
            EnotCtrl.hp-=15;
        }
        Debug.Log("KICK END");
    }
}
