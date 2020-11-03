using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject blade;

    void Throw() {
        if (blade == null) {
            Debug.Log("[" + this.name + "]"  + " No blade defined, can't thorw");
            return;
        }
        Instantiate(blade, new Vector3(0.921f,-3f,0f), Quaternion.identity);
    }
}
