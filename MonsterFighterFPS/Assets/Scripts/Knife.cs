using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;
    [SerializeField] float _range = 5f;
    EnemyHealth _enemyHealth;
    Animator _anim;
    [SerializeField] float _damage;
    [SerializeField] Text _ammoText;

    
    void Start() {
        _enemyHealth = FindObjectOfType<EnemyHealth>();

        _anim = GetComponent<Animator>();
    }

    void Update() {
        DisplayAmmo();
        KnifeAnimation();
    }
    
    void KnifeAnimation() {
        
        if(Input.GetMouseButtonDown(0)) {
            _anim.SetTrigger("stab");

        }
    }

    void DisplayAmmo() {
        _ammoText.text = "Infinite";
    }

    public void ProcessRayCast() {
        RaycastHit hit;

        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _range)) {
            
            if(hit.transform.tag == "Enemy") {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null) return;
                target.DamageTaken(_damage);
            } else if(hit.transform.tag == "Head") {
                EnemyHealth target = hit.transform.GetComponentInParent<EnemyHealth>();
                if (target == null) return;
                target.DamageTaken(_damage * 2);
            }
            
        } else {
            return;
        }
    }
}
