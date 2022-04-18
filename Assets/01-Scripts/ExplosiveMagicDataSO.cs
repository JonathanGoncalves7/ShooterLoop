using UnityEngine;

[CreateAssetMenu(fileName = "ExplosiveMagicDataSO", menuName = "ShooterLoop/ExplosiveMagicDataSO", order = 0)]
public class ExplosiveMagicDataSO : MagicDataSO
{
    [SerializeField] float RadiusDamage;

    [SerializeField] PlayerStatusSO PlayerStatus;

    [Header("Powerup")]
    [SerializeField] PowerupDataSO PowerupDamage;
    [SerializeField] PowerupDataSO PowerupCooldown;
    [SerializeField] PowerupDataSO PowerupArea;

    public override float GetCooldown()
    {
        return (Cooldown - PowerupCooldown.GetBonus(Cooldown));
    }

    public override int GetManaConsumption()
    {
        return ManaConsumption;
    }

    public override void Shoot(Transform shootPosition)
    {
        PlayerStatus.ReduceMana(GetManaConsumption());

        GameObject newProjectile = InstantiateNewProjectile(shootPosition, Prefab);

        int randomDamage = Damage.GetRandom();

        ExplosionProjectileBehavior explosionProjectile = newProjectile.GetComponent<ExplosionProjectileBehavior>();
        explosionProjectile.Speed = Speed;
        explosionProjectile.Damage = randomDamage + (int)PowerupDamage.GetBonus(randomDamage);
        explosionProjectile.RadiusDamage = RadiusDamage + (RadiusDamage - PowerupArea.GetBonus(RadiusDamage));

        _lastShoot = GetNewCooldown();
    }
}
