using UnityEngine;


[CreateAssetMenu(fileName = "WeaponShoot", menuName = "ShooterLoop/WeaponShoot", order = 0)]
public class MagicDataSO : ScriptableObject
{
    [SerializeField] ProjectileDataSO ProjectileData;
    [SerializeField] float FireRate;
    [SerializeField] int MaxProjectiles;
    [SerializeField] float TimeToRechargeProjectile;

    float _lastShoot;
    int _currentProjectilesCount;
    float _restTimeToRechargeProjectile;

    private void Start()
    {
        Ini();
    }

    public void Ini()
    {
        _lastShoot = Time.time + FireRate;

        _currentProjectilesCount = MaxProjectiles;
        _restTimeToRechargeProjectile = Time.time + TimeToRechargeProjectile;
    }

    private void Update()
    {
        RechargeProjectiles();
    }

    public bool CanShoot()
    {
        return Time.time > _lastShoot && _currentProjectilesCount > 0;
    }

    public void Shoot(Transform shootPosition)
    {
        GameObject newProjectile = Instantiate(ProjectileData.Prefab, shootPosition.position, shootPosition.rotation);

        ProjectileBehavior projectileBehavior = newProjectile.GetComponent<ProjectileBehavior>();
        projectileBehavior.Speed = ProjectileData.Speed;
        projectileBehavior.Damage = ProjectileData.Damage.GetRandom();
        projectileBehavior.RadiusDamage = ProjectileData.RadiusDamage;

        _lastShoot = Time.time + FireRate;
        _currentProjectilesCount--;
    }

    private void RechargeProjectiles()
    {
        if (_currentProjectilesCount >= MaxProjectiles || Time.time < _restTimeToRechargeProjectile) return;

        _currentProjectilesCount++;


        _restTimeToRechargeProjectile = Time.time + TimeToRechargeProjectile;
    }
}
