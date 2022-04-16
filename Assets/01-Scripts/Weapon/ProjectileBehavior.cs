using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [System.NonSerialized] public float Speed;
    [System.NonSerialized] public int Damage;

    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        Destroy(gameObject, 1);
    }

    protected void BasicDamage(GameObject enemy)
    {
        EnemyController damaged = enemy.GetComponent<EnemyController>();
        damaged.Damage(Damage);
    }
}
