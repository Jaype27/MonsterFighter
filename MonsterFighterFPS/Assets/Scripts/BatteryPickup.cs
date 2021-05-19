using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float _angleRestore = 70f;
    [SerializeField] float _intensityRestore = 1f;

    void OnTriggerEnter(Collider other) {
        other.GetComponentInChildren<Flashlight>().RestoreLightAngle(_angleRestore);
        other.GetComponentInChildren<Flashlight>().AddLightIntensity(_intensityRestore);

        Destroy(gameObject);
    }
}
