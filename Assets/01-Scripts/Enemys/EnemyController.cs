using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyController : MonoBehaviour, IDamaged
{
    Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public void Damage(int damage)
    {
        _health.CurrentHealth -= damage;

        if (_health.CurrentHealth <= 0)
            Destroy(gameObject);
    }
}
