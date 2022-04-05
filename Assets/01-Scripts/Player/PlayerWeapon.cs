using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] List<GameObject> WeaponList;

    private void Start()
    {
        ActiveWeaponIndex(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveWeaponIndex(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveWeaponIndex(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveWeaponIndex(2);
        }
    }

    private void ActiveWeaponIndex(int index)
    {
        for (int i = 0; i < WeaponList.Count; i++)
        {
            WeaponList[i].GetComponent<WeaponShoot>().IsActiveWeapon = (i == index);
        }
    }
}
