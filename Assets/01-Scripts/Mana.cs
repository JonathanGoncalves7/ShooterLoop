using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] int MaxMana;
    [SerializeField] int Regen;
    [SerializeField] float SecondsToRegen;

    int _currentMana;
    float restSecondsToRegen;

    private void Start()
    {
        _currentMana = MaxMana;

        restSecondsToRegen = Time.time + SecondsToRegen;
    }

    private void Update()
    {
        if (Time.time > restSecondsToRegen)
        {
            restSecondsToRegen = Time.time + SecondsToRegen;

            RegenMana();
        }
    }

    private void RegenMana()
    {
        Increment(Regen);
    }

    public int GetCurrentMana()
    {
        return _currentMana;
    }

    public void Increment(int value)
    {
        _currentMana += value;

        if (_currentMana > MaxMana)
            _currentMana = MaxMana;
    }

    public void Reduce(int value)
    {
        _currentMana -= value;

        if (_currentMana < 0)
            _currentMana = 0;
    }
}
