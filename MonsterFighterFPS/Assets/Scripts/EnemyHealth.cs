using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _healthPoints = 100f;
    Animator _anim;
    bool isDead = false;

    public bool IsDead() { return isDead; }

    void Start() {
        _anim = GetComponent<Animator>();
    }


    public void DamageTaken(float damage) {
        
        BroadcastMessage("OnDamageTaken");
        
        _healthPoints -= damage;

        if(_healthPoints <= 0) {
           Die();
        }
    }

    void Die() {
        
        if(isDead) return;
        isDead = true;
        _anim.SetTrigger("isDead");
    }
}
