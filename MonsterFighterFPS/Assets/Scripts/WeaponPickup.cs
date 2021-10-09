using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Transform _weaponPos;
    GameObject _weapon;
    

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Weapon") {
            _weapon = other.gameObject;
            _weapon.transform.position = _weaponPos.position;
            _weapon.transform.parent = _weaponPos;
            _weapon.transform.localEulerAngles = new Vector3(0, 180f, 0);
            // _weapon.transform.position = new Vector3(106.81f, 0.9f, 176.09f);
            _weapon.SetActive(false);
        }
    }

}
