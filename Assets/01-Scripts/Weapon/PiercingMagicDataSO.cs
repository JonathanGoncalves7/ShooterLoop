using UnityEngine;

[CreateAssetMenu(fileName = "PiercingMagicDataSO", menuName = "ShooterLoop/PiercingMagicDataSO", order = 0)]
public class PiercingMagicDataSO : MagicDataSO
{
    [SerializeField] int MaxTargetDamaged = 2;

    [SerializeField] PlayerStatusSO PlayerStatus;

    [Header("Powerup")]
    [SerializeField] PowerupDataSO PowerupDamage;
    [SerializeField] PowerupDataSO PowerupCooldown;
    [SerializeField] PowerupDataSO PowerupDistance;

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

        PiercingProjectileBehavior piercingProjectile = newProjectile.GetComponent<PiercingProjectileBehavior>();
        piercingProjectile.Speed = Speed;
        piercingProjectile.Damage = randomDamage + (int)PowerupDamage.GetBonus(randomDamage);
        piercingProjectile.MaxTargetDamaged = MaxTargetDamaged + (int)PowerupDistance.GetBonus(MaxTargetDamaged);
        piercingProjectile.SpellCastingClip = GetSpellCasting();

        _lastShoot = GetNewCooldown();
    }
}
