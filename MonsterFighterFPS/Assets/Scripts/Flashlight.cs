using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float _lightDecay = 0.1f;
    [SerializeField] float _angleDecay = 1f;
    [SerializeField] float _minAngle = 40f;

    float _maxAngle = 70f;
    float _maxIntensity = 4f;

    Light _myLight;

    void Start() {
        _myLight = GetComponent<Light>();
    }

    void Update() {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle) {
        _myLight.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float intensityAmount) {
        _myLight.intensity += intensityAmount;
    }

    void DecreaseLightAngle() {
        
        if(_myLight.spotAngle <= _minAngle) { 
            return; 
        } else {
            _myLight.spotAngle -= _angleDecay * Time.deltaTime;
        }
    }

    void DecreaseLightIntensity() {
        _myLight.intensity -= _lightDecay * Time.deltaTime;
    }
}
