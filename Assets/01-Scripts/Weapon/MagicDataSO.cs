using UnityEngine;


[CreateAssetMenu(fileName = "WeaponShoot", menuName = "ShooterLoop/WeaponShoot", order = 0)]
public class MagicDataSO : ScriptableObject
{
    [SerializeField] ProjectileDataSO ProjectileData;
    [SerializeField] float Cooldown;
    [SerializeField] int ManaConsumption;

    float _lastShoot;

    private void Start()
    {
        Ini();
    }

    public void Ini()
    {
        _lastShoot = Time.time + Cooldown;
    }

    public bool CanShoot(int currentMana)
    {
        return Time.time > _lastShoot && ManaConsumption <= currentMana;
    }

    public void Shoot(Transform shootPosition)
    {
        GameObject newProjectile = Instantiate(ProjectileData.Prefab, shootPosition.position, shootPosition.rotation);

        ProjectileBehavior projectileBehavior = newProjectile.GetComponent<ProjectileBehavior>();
        projectileBehavior.Speed = ProjectileData.Speed;
        projectileBehavior.Damage = ProjectileData.Damage.GetRandom();
        projectileBehavior.RadiusDamage = ProjectileData.RadiusDamage;

        _lastShoot = Time.time + Cooldown;
    }

    public int GetManaConsumption()
    {
        return ManaConsumption;
    }
}
