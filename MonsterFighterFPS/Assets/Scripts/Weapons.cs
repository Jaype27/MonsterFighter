using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{

    [SerializeField] Camera _fpCamera;
    [Range(5f, 50f)][SerializeField] float _range;
    [Range(1f, 30f)] [SerializeField] float _damage;
    [Range(0.1f, 1.0f)] [SerializeField] float _fireRate;
    [Range(0.1f, 1.0f)] [SerializeField] float _nextShot;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType _ammoType;
    
    [SerializeField] Text _ammoText;
    bool _canShoot = true;
    [SerializeField] AudioSource _shootSound;
    
    // [SerializeField] ParticleSystem _bulletShot;

    


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
            PlayShootSound();
            ProcessRayCast();
            
            _ammoSlot.ShootCurrentAmmo(_ammoType);
        }
    }

    void PlayMuzzleFlash() {
        _muzzleFlash.Play();
    }

    void PlayShootSound() {
        _shootSound.Play();
    }

    private void ProcessRayCast() {
        RaycastHit hit;

        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _range)) {
            
            if(hit.transform.tag == "Enemy") {
                HitImpact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null) return;
                target.DamageTaken(_damage);
            } else if(hit.transform.tag == "Head") {
                HitImpact(hit);
                EnemyHealth target = hit.transform.GetComponentInParent<EnemyHealth>();
                if (target == null) return;
                target.DamageTaken(_damage * 2);
            }
            
        } else {
            return;
        }
    }

    void HitImpact(RaycastHit hit) {
       GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 0.1f);
    }

    /*void PlayShot() {
        _bulletShot.Play();
    }*/

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
