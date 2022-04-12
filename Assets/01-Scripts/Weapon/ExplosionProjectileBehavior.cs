using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectileBehavior : ProjectileBehavior
{
    [System.NonSerialized] public float RadiusDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Enemy"))
            AreaDamage();

        Destroy(gameObject);
    }

    private void AreaDamage()
    {
        Collider[] hit;
        hit = Physics.OverlapSphere(transform.position, RadiusDamage);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.CompareTag("Enemy"))
            {
                BasicDamage(hit[i].transform.gameObject);
            }
        }
    }
}