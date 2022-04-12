using System;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public int Damage;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    protected void BasicDamage(GameObject enemy)
    {
        EnemyController damaged = enemy.GetComponent<EnemyController>();
        damaged.Damage(Damage);
    }
}
