using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class EnemyController : MonoBehaviour, IDamaged
{
    Health _health;
    NavMeshAgent _navMeshAgent;
    Collider _collider;
    EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _health = GetComponent<Health>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    public void Damage(int damage)
    {
        _health.CurrentHealth -= damage;

        if (_health.CurrentHealth <= 0)
        {
            _navMeshAgent.enabled = false;
            _collider.enabled = false;

            _enemyAnimations.Die();

            Destroy(gameObject, 5);
        }
    }
}