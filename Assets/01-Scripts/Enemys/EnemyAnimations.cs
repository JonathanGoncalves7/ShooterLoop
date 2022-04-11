using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimations : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _animator = transform.GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);
    }

    public void Attack()
    {
        int randomIndex = Random.Range(0, 1);

        if (randomIndex == 0)
        {
            _animator.SetTrigger("Attack 01");
        }
        else
        {
            _animator.SetTrigger("Attack 02");
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
    }
}
