﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteract : MonoBehaviour
{
    
    [SerializeField] Camera _fpsCamera;
    [SerializeField] float _range;
    [SerializeField] int _fuses = 0;
    [SerializeField] Canvas _interactText;
    
    // Start is called before the first frame update
    void Start() {
        _interactText.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        ProcessRayCast();
    }

    void ProcessRayCast() {
        RaycastHit hit;

        if(Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range)) {
            _interactText.enabled = true;
            if(hit.transform.tag == "Gate") {
                if(Input.GetKeyDown(KeyCode.E)) {
                    if(_fuses >= 3) {
                        GateFunctions gateFunctions = hit.transform.GetComponent<GateFunctions>();
                        if(gateFunctions == null) return;
                        gateFunctions.GateOpen();
                    } else {
                        Debug.Log("Insufficient Fuses");
                    }
                }           
            } else if(hit.transform.tag == "End") {
                if(Input.GetKeyDown(KeyCode.E)) {
                    GetComponent<DeathHandler>().EndGame();
                }           
            }
        } else {
            _interactText.enabled = false;
            return;
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Fuse") {
            other.gameObject.SetActive(false);
            _fuses++;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
