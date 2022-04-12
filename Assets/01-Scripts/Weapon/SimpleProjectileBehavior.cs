using UnityEngine;

public class SimpleProjectileBehavior : ProjectileBehavior
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Enemy"))
            BasicDamage(other.gameObject);

        Destroy(gameObject);
    }
}
