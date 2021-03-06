using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatusSO", menuName = "ShooterLoop/PlayerStatusSO", order = 0)]
public class PlayerStatusSO : ScriptableObject
{
    [Header("Health")]
    [SerializeField] int MaxHealth;

    [Header("Mana")]
    [SerializeField] int MaxMana;
    [SerializeField] int Regen;
    [SerializeField] float SecondsToRegen;

    [Header("Powerup")]
    [SerializeField] PowerupDataSO powerupHealth;
    [SerializeField] PowerupDataSO powerupMana;
    [SerializeField] PowerupDataSO powerupRegenMana;

    [SerializeField] GameObject HitVFX;

    [System.NonSerialized] public int CurrentHealth;
    [System.NonSerialized] public int CurrentMana;

    float restSecondsToRegen;

    private void OnEnable()
    {
        IniValues();
    }

    public void IniValues()
    {
        CurrentHealth = GetMaxHealth();
        CurrentMana = GetMaxMana();

        restSecondsToRegen = Time.time + GetSecondsToRegenMana();
    }

    public int GetMaxHealth()
    {
        return MaxHealth + (int)powerupHealth.GetBonus(MaxHealth);
    }

    public int GetMaxMana()
    {
        return MaxMana + (int)powerupMana.GetBonus(MaxMana);
    }

    private float GetSecondsToRegenMana()
    {
        return SecondsToRegen - powerupRegenMana.GetBonus(SecondsToRegen);
    }

    public void Damage(int damage, Vector3 damagePosition)
    {
        CurrentHealth -= damage;

        ShowHitVFX(damagePosition);
        UIManager.s_instance.ShowDamagePopup(damage, damagePosition);

        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }

    private void ShowHitVFX(Vector3 positionVFX)
    {
        GameObject newVFX = Instantiate(HitVFX, positionVFX, Quaternion.identity);
        Destroy(newVFX, 1);
    }

    public void RegenMana()
    {
        if (Time.time < restSecondsToRegen) return;

        restSecondsToRegen = Time.time + GetSecondsToRegenMana();

        IncrementMana(Regen);
    }

    public int GetCurrentMana()
    {
        return CurrentMana;
    }

    public void IncrementMana(int value)
    {
        CurrentMana += value;

        if (CurrentMana > GetMaxMana())
            CurrentMana = GetMaxMana();
    }

    public void ReduceMana(int value)
    {
        CurrentMana -= value;

        if (CurrentMana < 0)
            CurrentMana = 0;
    }
}