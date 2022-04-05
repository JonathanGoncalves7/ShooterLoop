using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    int _currentHealth;

    private void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void Damage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }
}
