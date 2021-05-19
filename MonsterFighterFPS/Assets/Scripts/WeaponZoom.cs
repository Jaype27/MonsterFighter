using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] RigidbodyFirstPersonController _fpsController;
    [SerializeField] float _zoomInFOV = 25f;
    [SerializeField] float _mouseSensitivityZoom = 0.5f;
    
    float _zoomOutFOV = 60f;
    float _mouseSensitivityNormal = 2f;

    void OnDisable() {
        ZoomOut();
    }
    
    void Update() {
        if(Input.GetMouseButton(1)) {
            ZoomIn();

        } else {
            ZoomOut();
        }
    }

    void ZoomIn() {
        _fpsCamera.fieldOfView = _zoomInFOV;
        _fpsController.mouseLook.XSensitivity = _mouseSensitivityZoom;
        _fpsController.mouseLook.YSensitivity = _mouseSensitivityZoom;
    }

    void ZoomOut() {
        _fpsCamera.fieldOfView = _zoomOutFOV;
        _fpsController.mouseLook.XSensitivity = _mouseSensitivityNormal;
        _fpsController.mouseLook.YSensitivity = _mouseSensitivityNormal;
    }
}
