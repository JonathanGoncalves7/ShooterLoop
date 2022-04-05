using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] ProjectileDataSO ProjectileData;
    [SerializeField] Transform ShootPosition;
    [SerializeField] float FireRate;
    [SerializeField] int MaxProjectiles;
    [SerializeField] float TimeToRechargeProjectile;

    [Header("Recoil")]
    [SerializeField] float RecoilShoot;
    [SerializeField] float RecoilSpeed;

    public bool IsActiveWeapon;

    float _lastShoot;
    Vector3 _iniPos;
    [SerializeField] int _currentProjectilesCount;
    float _restTimeToRechargeProjectile;
    MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _lastShoot = Time.time + FireRate;
        _iniPos = transform.localPosition;

        _currentProjectilesCount = MaxProjectiles;
        _restTimeToRechargeProjectile = Time.time + TimeToRechargeProjectile;
    }

    private void Update()
    {
        _meshRenderer.enabled = IsActiveWeapon;

        Shoot();
        RechargeProjectiles();
        ReturnRecoil();
    }

    private void Shoot()
    {
        if (Input.GetAxis("Fire1") <= 0 || Time.time < _lastShoot || _currentProjectilesCount <= 0 || !IsActiveWeapon) return;

        GameObject newProjectile = Instantiate(ProjectileData.Prefab, ShootPosition.position, ShootPosition.rotation);

        ProjectileBehavior projectileBehavior = newProjectile.GetComponent<ProjectileBehavior>();
        projectileBehavior.Speed = ProjectileData.Speed;
        projectileBehavior.Damage = ProjectileData.Damage.GetRandom();
        projectileBehavior.RadiusDamage = ProjectileData.RadiusDamage;

        _lastShoot = Time.time + FireRate;
        _currentProjectilesCount--;

        Recoil();
    }

    private void RechargeProjectiles()
    {
        if (_currentProjectilesCount >= MaxProjectiles || Time.time < _restTimeToRechargeProjectile) return;

        _currentProjectilesCount++;


        _restTimeToRechargeProjectile = Time.time + TimeToRechargeProjectile;
    }

    private void Recoil()
    {
        float recoil = _iniPos.z - RecoilShoot;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, recoil);
    }

    private void ReturnRecoil()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _iniPos, RecoilSpeed);
    }
}
