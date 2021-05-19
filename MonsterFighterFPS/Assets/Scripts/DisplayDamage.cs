using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas _impactCanvas;
    [SerializeField] float _displayTime = 0.3f;


    void Start() {
        _impactCanvas.enabled = false;
    }

    void Update() {
        
    }

    public void ShowDamageImpact() {
        StartCoroutine(DisplayDamageImpact());
    }

    IEnumerator DisplayDamageImpact() {

        _impactCanvas.enabled = true;
        yield return new WaitForSeconds(_displayTime);
        _impactCanvas.enabled = false;
    }
}
