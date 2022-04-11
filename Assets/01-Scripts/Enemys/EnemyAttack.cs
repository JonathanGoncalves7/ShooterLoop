using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] MinAndMax Damage;
    [SerializeField] float AttackRange;
    [SerializeField] float AttackRate;

    GameObject _player;
    PlayerStatusSO _playerStatus;
    float _lastAttack;
    EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();

        _lastAttack = Time.time + AttackRate;
    }

    private void Update()
    {
        Attack();
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
        _playerStatus = player.GetComponent<PlayerController>().PlayerStatus;
    }

    private void Attack()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) > AttackRange || Time.time < _lastAttack) return;

        _enemyAnimations.Attack();

        int damage = Damage.GetRandom();
        _playerStatus.Damage(damage);

        _lastAttack = Time.time + AttackRate;

        Debug.Log("Damage Player:" + damage);
    }
}
