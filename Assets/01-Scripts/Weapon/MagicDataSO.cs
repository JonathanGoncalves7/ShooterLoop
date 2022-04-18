using UnityEngine;

public abstract class MagicDataSO : ScriptableObject
{
    [SerializeField] protected GameObject Prefab;
    [SerializeField] protected float Speed;
    [SerializeField] protected MinAndMax Damage;
    [SerializeField] protected float Cooldown;
    [SerializeField] protected int ManaConsumption;

    protected float _lastShoot;

    private void OnEnable()
    {
        _lastShoot = GetNewCooldown();
    }

    public bool CanShoot(int currentMana)
    {
        return Time.time > _lastShoot && GetManaConsumption() <= currentMana;
    }

    public GameObject InstantiateNewProjectile(Transform shootPosition, GameObject prefab)
    {
        return Instantiate(prefab, shootPosition.position, shootPosition.rotation);
    }

    private void SingleDamage(GameObject enemy, int damage)
    {
        EnemyController damaged = enemy.GetComponent<EnemyController>();
        damaged.Damage(damage);
    }

    public float GetRestCooldown()
    {
        return (_lastShoot - Time.time) / GetCooldown();
    }

    protected float GetNewCooldown()
    {
        return Time.time + GetCooldown();
    }

    public abstract float GetCooldown();
    public abstract int GetManaConsumption();
    public abstract void Shoot(Transform shootPosition);
}
