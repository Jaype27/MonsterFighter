using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    [SerializeField] float _chaseRange = 5f;
    [SerializeField] float _turnSpeed = 3f;
    [SerializeField] SphereCollider[] _sphereCollider;
    float _moveSpeed;

    NavMeshAgent _navMeshAgent;
    float _detectRange = Mathf.Infinity;
    bool isProvoked = false;
    Animator _anim;
    EnemyHealth _enemyHealth;
    Transform _target;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _target = FindObjectOfType<PlayerHealth>().transform;

        _moveSpeed = _navMeshAgent.speed;
        // _navMeshAgent.speed = _moveSpeed;

        _sphereCollider = GetComponentsInChildren<SphereCollider>();


    }

    void Update()
    {

        if (_enemyHealth.IsDead())
        {
            enabled = false;
            _navMeshAgent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }


        SetDestination();
    }

    void SetDestination()
    {
        _detectRange = Vector3.Distance(_target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (_detectRange <= _chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();

        if (_detectRange >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            _anim.SetTrigger("idle");
        }

        if (_detectRange <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    void ChaseTarget()
    {
        _anim.SetBool("attack", false);
        _anim.SetTrigger("move");
        _navMeshAgent.SetDestination(_target.position);

        foreach (SphereCollider sphere in _sphereCollider)
        {
            sphere.enabled = false;
        }
    }

    void AttackTarget()
    {
        _anim.SetBool("attack", true);
        foreach (SphereCollider sphere in _sphereCollider)
        {
            sphere.enabled = true;
        }

    }

    public void StopMove()
    {
        // _navMeshAgent.speed = 0;
        _navMeshAgent.enabled = false;

    }

    public void NormalMove()
    {
        _navMeshAgent.enabled = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
