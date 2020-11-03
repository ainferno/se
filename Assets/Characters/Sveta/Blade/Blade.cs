using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float speed = 5f;

    void Update() {
        this.transform.position += new Vector3(speed * -1,0f,0f) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collider2D other) {
        Debug.Log("COLLISION");
        Destroy(this.gameObject);
    }
}
