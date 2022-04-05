using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] ProjectileDataSO ProjectileData;
    [SerializeField] Transform ShootPosition;
    [SerializeField] float FireRate;

    [Header("Recoil")]
    [SerializeField] float RecoilShoot;
    [SerializeField] float RecoilSpeed;

    float lastShoot;
    Vector3 iniPos;

    private void Start()
    {
        lastShoot = Time.time + FireRate;
        iniPos = transform.localPosition;
    }

    private void Update()
    {
        Shoot();

        ReturnRecoil();
    }

    private void Shoot()
    {
        if (Input.GetAxis("Fire1") <= 0 || Time.time < lastShoot) return;

        GameObject newProjectile = Instantiate(ProjectileData.Prefab, ShootPosition.position, ShootPosition.rotation);

        ProjectileBehavior projectileBehavior = newProjectile.GetComponent<ProjectileBehavior>();
        projectileBehavior.Speed = ProjectileData.Speed;
        projectileBehavior.Damage = ProjectileData.Damage.GetRandom();

        lastShoot = Time.time + FireRate;

        Recoil();
    }

    private void Recoil()
    {
        float recoil = iniPos.z - RecoilShoot;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, recoil);
    }

    private void ReturnRecoil()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, iniPos, RecoilSpeed);
    }
}
