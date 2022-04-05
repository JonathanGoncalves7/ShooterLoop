using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float MinDistanceTarget = 5f;
    [SerializeField] MinAndMax Speed;

    NavMeshAgent _navMeshAgent;
    GameObject _player;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = Speed.GetRandom();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) > MinDistanceTarget)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.destination = _player.transform.position;
        }
        else
        {
            _navMeshAgent.isStopped = true;
        }
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}
