using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnotController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpVel = 22f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator an;

    public float hp = 100;
    public Image hpBar;

    public GameObject SvetaWinsBanner;
    public GameObject Sveta;

    private SvetaController SvetaCtrl;

    private Dictionary<string, bool> collision = new Dictionary<string, bool>();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        an = GetComponent<Animator>();

        SvetaCtrl = Sveta.GetComponent<SvetaController>();
    }
    
    void Update() {
        Move();

        if (hp <= 0) {
            SvetaWinsBanner.SetActive(true);
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
            if (Input.GetKey(KeyCode.W)) {
                // an.SetBool("air", true);
                rb.velocity = Vector2.up * jumpVel;
            }
        }
        float x = 0;
        if (Input.GetKey(KeyCode.A)) {
            x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            x = 1;
        }

        float moveBy = x * speed;
        if (moveBy != 0) {
            an.SetBool("walking",true);
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        } else {
            an.SetBool("walking",false);
        }

        if (Input.GetKeyDown("c")) {
            an.SetBool("punch", true);
        } else {
            an.SetBool("punch", false);
        }
        if (Input.GetKey("v")) {
            an.SetBool("kikl", true);
        } else {
            an.SetBool("kikl", false);
        }
        if (Input.GetKey("b")) {
            an.SetBool("kikh", true);
        } else {
            an.SetBool("kikh", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collision[other.gameObject.tag] = true;   
    }

    private void OnCollisionExit2D(Collision2D other) {
        collision[other.gameObject.tag] = false;
    }

    public void Punch() {
        Debug.Log("PUNCH START");
        float dist = Vector3.Distance(Sveta.transform.position, transform.position);
        Debug.Log("PUNCH dist: " + dist);
        if (dist < 5f) {
            SvetaCtrl.hp-=5;
        }
        Debug.Log("PUNCH END");
    }

    public void KickL() {
        Debug.Log("KICKL START");
        float dist = Vector3.Distance(Sveta.transform.position, transform.position);
        Debug.Log("KICKL dist: " + dist);
        if (dist < 5f) {
            SvetaCtrl.hp-=5;
        }
        Debug.Log("KICKL END");
    }

    public void KickH() {
        Debug.Log("KICKH START");
        float dist = Vector3.Distance(Sveta.transform.position, transform.position);
        Debug.Log("KICKH dist: " + dist);
        if (dist < 7f) {
            SvetaCtrl.hp-=30;
        }
        Debug.Log("KICKH END");
    }
}
