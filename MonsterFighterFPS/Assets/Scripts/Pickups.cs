using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] int _ammoAmount = 5;
    [SerializeField] AmmoType _ammoType;
    

    
    void OnTriggerEnter(Collider other) {
        
        other.GetComponent<Ammo>().IncreaseAmmoType(_ammoType, _ammoAmount);
        Destroy(gameObject);
    }
}
