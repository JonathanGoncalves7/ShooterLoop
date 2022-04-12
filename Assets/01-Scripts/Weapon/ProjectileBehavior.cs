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
        IDamaged damaged = enemy.GetComponent<IDamaged>();
        damaged.Damage(Damage);
    }
}
