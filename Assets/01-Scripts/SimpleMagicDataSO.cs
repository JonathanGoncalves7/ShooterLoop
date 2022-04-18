using UnityEngine;

[CreateAssetMenu(fileName = "SimpleMagicDataSO", menuName = "ShooterLoop/SimpleMagicDataSO", order = 0)]
public class SimpleMagicDataSO : MagicDataSO
{
    [SerializeField] PlayerStatusSO PlayerStatus;

    [Header("Powerup")]
    [SerializeField] PowerupDataSO PowerupDamage;
    [SerializeField] PowerupDataSO PowerupCooldown;
    [SerializeField] PowerupDataSO PowerupMana;

    public override float GetCooldown()
    {
        return (Cooldown - PowerupCooldown.GetBonus(Cooldown));
    }

    public override int GetManaConsumption()
    {
        return ManaConsumption - (int)PowerupMana.GetBonus(ManaConsumption);
    }

    public override void Shoot(Transform shootPosition)
    {
        PlayerStatus.ReduceMana(GetManaConsumption());

        GameObject newProjectile = InstantiateNewProjectile(shootPosition, Prefab);

        int randomDamage = Damage.GetRandom();

        SimpleProjectileBehavior simpleProjectile = newProjectile.GetComponent<SimpleProjectileBehavior>();
        simpleProjectile.Speed = Speed;
        simpleProjectile.Damage = randomDamage + (int)PowerupDamage.GetBonus(randomDamage);

        _lastShoot = GetNewCooldown();
    }
}
