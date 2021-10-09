using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicked : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GetComponent<Weapons>().enabled = true;
            GetComponent<WeaponZoom>().enabled = true;
            GetComponent<SphereCollider>().enabled = false;
            this.enabled = false;
        }
    }
}
