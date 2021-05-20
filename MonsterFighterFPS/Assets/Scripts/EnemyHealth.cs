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

    void OnParticleCollision(GameObject other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if(!damageDealer) { return; }
        DamageTaken(damageDealer);
    }


    public void DamageTaken(DamageDealer damageDealer) {
        
        BroadcastMessage("OnDamageTaken");
        
        _healthPoints -= damageDealer.GetDamage();

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
