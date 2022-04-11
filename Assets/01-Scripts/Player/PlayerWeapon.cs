using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] MagicDataSO SimplesMagic;
    [SerializeField] MagicDataSO GreatMagic;
    [SerializeField] MagicDataSO ExplosionMagic;

    [SerializeField] Transform ShootPosition;

    MagicDataSO _currentWeaponActive;
    bool _canShoot;
    PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();

        SimplesMagic.Ini();
        GreatMagic.Ini();
        ExplosionMagic.Ini();

        ActiveWeaponIndex(0);
    }

    private void Update()
    {
        SetActiveWeapon();

        StartShoot();
    }

    private void StartShoot()
    {
        if (Input.GetAxis("Fire1") <= 0 || !_currentWeaponActive.CanShoot(_playerController.Mana.GetCurrentMana())) return;

        _playerController.UseMagic(_currentWeaponActive.GetManaConsumption());
        _currentWeaponActive.Shoot(ShootPosition);
    }

    private void SetActiveWeapon()
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
        switch (index)
        {
            case 0:
                _currentWeaponActive = SimplesMagic;
                break;
            case 1:
                _currentWeaponActive = GreatMagic;
                break;
            case 2:
                _currentWeaponActive = ExplosionMagic;
                break;
        }
    }
}
