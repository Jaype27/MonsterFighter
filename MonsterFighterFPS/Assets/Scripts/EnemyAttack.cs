using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    PlayerHealth _target;
    [SerializeField] float _damage = 5f;
    
    
    void Start() {
        _target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() {
        if(_target == null) {
            return;
        }

        _target.DamageTaken(_damage);

        _target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    
}
