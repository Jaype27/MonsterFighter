using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float _healthAmmount;

    void OnTriggerEnter(Collider other) {
        

        other.GetComponent<PlayerHealth>().RestoreHealth(_healthAmmount);
        Destroy(gameObject);
    }
}
