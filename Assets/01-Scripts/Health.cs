using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
