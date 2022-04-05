using System;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public int Damage;
    [System.NonSerialized] public float RadiusDamage;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Enemy"))
        {
            if (RadiusDamage > 0)
            {
                AreaDamage();
            }
            else
            {
                SingleDamage(other.gameObject);
            }
        }

        Destroy(gameObject);
    }

    private void SingleDamage(GameObject enemy)
    {
        IDamaged damaged = enemy.GetComponent<IDamaged>();
        damaged.Damage(Damage);
    }

    private void AreaDamage()
    {
        Collider[] hit;
        hit = Physics.OverlapSphere(transform.position, RadiusDamage);

        for (int i = 0; i < hit.Length; i++)
        {
            if (!hit[i].transform.CompareTag("Enemy")) continue;

            IDamaged damaged = hit[i].transform.gameObject.GetComponent<IDamaged>();
            damaged.Damage(Damage);         
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, RadiusDamage);
    }
}
