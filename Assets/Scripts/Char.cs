using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public Slider health_bar;

    void Update() {
        
    }

    public void Hit(int damage) {
        Debug.Log(name + " is damaged by " + damage);
        health-=damage;
        health_bar.value = health;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        Debug.Log(name + " is dead");
        Destroy(this.gameObject);
    }
}
