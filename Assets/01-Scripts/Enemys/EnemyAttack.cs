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
    float _lastAttack;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _lastAttack = Time.time + AttackRate;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) > AttackRange || Time.time < _lastAttack) return;

        int damage = Damage.GetRandom();
        _player.GetComponent<IDamaged>().Damage(damage);

        _lastAttack = Time.time + AttackRate;

        Debug.Log("Damage Player:" + damage);
    }
}
