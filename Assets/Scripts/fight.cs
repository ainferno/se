using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight : MonoBehaviour
{
    public bool punching;
    public GameObject punch;

    private Animator an;
    private Damage punch_damage;

    void Start() {
        an = GetComponent<Animator>();
        punch_damage = punch.GetComponent<Damage>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Punch();
        }
    }

    private void Punch() {
        if (!punching) {
            an.SetTrigger("punch");
        }
    }

    private void _punch() {
        punch_damage.Punch();
    }
}
