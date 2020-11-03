using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private List<GameObject> colliding = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other) {
        colliding.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliding.Remove(other.gameObject);
    }

    public void Punch() {
        foreach (GameObject col in colliding) {
            col.GetComponent<Char>().Hit(damage);
        }
    }
}
