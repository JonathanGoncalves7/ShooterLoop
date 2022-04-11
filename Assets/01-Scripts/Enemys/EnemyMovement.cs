using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float MinDistanceTarget = 5f;
    [SerializeField] MinAndMax Speed;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = Speed.GetRandom();
    }

    public bool ReachedTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(transform.position, targetPosition) <= MinDistanceTarget;
    }

    public void MoveToTarget(Vector3 targetPosition)
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.destination = targetPosition;
    }

    public void Stop()
    {
        _navMeshAgent.isStopped = true;
    }
}
