using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatusSO", menuName = "ShooterLoop/PlayerStatusSO", order = 0)]
public class PlayerStatusSO : ScriptableObject, IDamaged
{
    [Header("Health")]
    [SerializeField] int MaxHealth;

    [Header("Mana")]
    [SerializeField] int MaxMana;
    [SerializeField] int Regen;
    [SerializeField] float SecondsToRegen;

    [System.NonSerialized] public int CurrentHealth;
    [System.NonSerialized] public int CurrentMana;

    float restSecondsToRegen;

    public void Ini()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;

        restSecondsToRegen = Time.time + SecondsToRegen;
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }

    public void RegenMana()
    {
        if (Time.time < restSecondsToRegen) return;

        restSecondsToRegen = Time.time + SecondsToRegen;

        IncrementMana(Regen);
    }

    public int GetCurrentMana()
    {
        return CurrentMana;
    }

    public void IncrementMana(int value)
    {
        CurrentMana += value;

        if (CurrentMana > MaxMana)
            CurrentMana = MaxMana;
    }

    public void ReduceMana(int value)
    {
        CurrentMana -= value;

        if (CurrentMana < 0)
            CurrentMana = 0;
    }
}