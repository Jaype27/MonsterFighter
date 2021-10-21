using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float _healthPoints = 100f;
    [SerializeField] SphereCollider[] _sphereCollider;
    EnemyAI _enemyAI;
    Animator _anim;
    bool isDead = false;

    public bool IsDead() { return isDead; }

    void Start()
    {
        _anim = GetComponent<Animator>();
        // _enemyAI = GetComponent<EnemyAI>();
    }



    public void DamageTaken(float damage)
    {

        DamageDealer damageDealer = GetComponent<DamageDealer>();

        BroadcastMessage("OnDamageTaken"); // EnemyAI

        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            Die();
        }
    }


    void Die()
    {

        if (isDead) return;
        isDead = true;
        _anim.SetTrigger("isDead");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponentInChildren<BoxCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        _sphereCollider = GetComponentsInChildren<SphereCollider>();

        foreach (SphereCollider sphere in _sphereCollider)
        {
            sphere.enabled = false;
        }

    }


    /*void OnParticleCollision(GameObject other) {
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
    }*/
}
