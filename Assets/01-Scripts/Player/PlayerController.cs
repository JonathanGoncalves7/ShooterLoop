using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour, IDamaged
{
    public Health Health;
    public Mana Mana;

    private void Start()
    {
        Health = GetComponent<Health>();
        Mana = GetComponent<Mana>();
    }

    public void Damage(int damage)
    {
        Health.CurrentHealth -= damage;

        if (Health.CurrentHealth <= 0)
            GameManager.s_instance.UpdateGameState(GameState.Lose);
    }

    public void UseMagic(int spendMana)
    {
        Mana.Reduce(spendMana);
    }
}
