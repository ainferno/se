using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ch1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpVel = 22f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator an;

    private Dictionary<string, bool> collision = new Dictionary<string, bool>();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        an = GetComponent<Animator>();
    }
    
    void Update() {
        Move();
    }

    void Move() {
        if (collision["ground"]) {
            an.SetBool("air", false);
            if (Input.GetAxisRaw("Jump") == 1) {
                an.SetBool("air", true);
                rb.velocity = Vector2.up * jumpVel;
            }
        }
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        Debug.Log(moveBy);
        if (moveBy != 0) {
            an.SetBool("walking",true);
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        } else {
            an.SetBool("walking",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collision[other.gameObject.tag] = true;   
    }

    private void OnCollisionExit2D(Collision2D other) {
        collision[other.gameObject.tag] = false;
    }
}
