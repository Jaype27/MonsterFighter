using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{

    [SerializeField] Camera _fpCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] float _fireRate = 0.5f;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType _ammoType;
    [SerializeField] float _nextShot = 0.5f;
    [SerializeField] Text _ammoText;
    bool _canShoot = true;


    private void OnEnable() {
        _canShoot = true;
    }
    
    void Update() {
        
        DisplayAmmo();
        
        if(Input.GetMouseButton(0) && Time.time > _nextShot) {
            _nextShot = Time.time + _fireRate;
            Shoot();
        }
    }

    void DisplayAmmo() {
        int currentAmmo = _ammoSlot.GetCurrentAmmo(_ammoType);

        _ammoText.text = currentAmmo.ToString();
    }

    void Shoot() {

        if(_ammoSlot.GetCurrentAmmo(_ammoType) > 0) {
        
            PlayMuzzleFlash();
            ProcessRayCast();

            _ammoSlot.ShootCurrentAmmo(_ammoType);
        }
       
    }

    void PlayMuzzleFlash() {
        _muzzleFlash.Play();
    }

    private void ProcessRayCast() {
        RaycastHit hit;

        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _range)) {
            
            HitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.DamageTaken(_damage);
        } else {
            return;
        }
        
    }

    void HitImpact(RaycastHit hit) {
       GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 0.1f);
    }
}
