using UnityEngine;

[CreateAssetMenu(fileName = "PowerupDataSO", menuName = "ShooterLoop/PowerupDataSO", order = 0)]
public class PowerupDataSO : ScriptableObject
{
    [SerializeField] PowerupType type;
    [Range(0, 1)] [SerializeField] float PercentageEachLevel;
    [Range(5, 10)] [SerializeField] int MaxLevel = 5;
    [SerializeField] int ValueEachLevel = 100;

    int _currentLevel;

    private void OnEnable()
    {
        Load();
    }

    public void Load()
    {
        string typeString = GetTypeString();

        _currentLevel = PlayerPrefs.GetInt(typeString, 0);
    }


    public void Save()
    {
        string typeString = GetTypeString();

        PlayerPrefs.SetInt(typeString, _currentLevel);
    }

    public void Inc()
    {
        _currentLevel++;

        _currentLevel = Mathf.Min(_currentLevel, MaxLevel);

        Save();
    }

    public int GetValue()
    {
        return (_currentLevel + 1) * ValueEachLevel;
    }

    public bool IsMaxLevel()
    {
        return _currentLevel == MaxLevel;
    }

    public float GetBonus(int baseValue)
    {
        return baseValue * (_currentLevel * PercentageEachLevel);
    }

    public float GetBonus(float baseValue)
    {
        return baseValue * (_currentLevel * PercentageEachLevel);
    }

    public string GetTypeString()
    {
        switch (type)
        {
            case PowerupType.Health:
                return "HEALTH";
            case PowerupType.Mana:
                return "MANA";
            case PowerupType.RegenMana:
                return "REGENMANA";
            case PowerupType.Speed:
                return "SPEED";
            case PowerupType.SimpleDamage:
                return "SIMPLEDAMAGE";
            case PowerupType.SimpleCooldown:
                return "SIMPLECOOLDOWN";
            case PowerupType.SimpleMana:
                return "SIMPLEMANA";
            case PowerupType.PiercingDamage:
                return "PIERCINGDAMAGE";
            case PowerupType.PiercingCooldown:
                return "PIERCINGCOOLDOWN";
            case PowerupType.PiercingDistance:
                return "PIERCINGDISTANCE";
            case PowerupType.ExplosionDamage:
                return "EXPLOSIONDAMAGE";
            case PowerupType.ExplosionCooldown:
                return "EXPLOSIONCOOLDOWN";
            case PowerupType.ExplosionArea:
                return "EXPLOSIONAREA";
        }

        return "";
    }


    public int GetCurrentLevel()
    {
        return _currentLevel;
    }



    public enum PowerupType
    {
        Health,
        Mana,
        RegenMana,
        Speed,
        SimpleDamage,
        SimpleCooldown,
        SimpleMana,
        PiercingDamage,
        PiercingCooldown,
        PiercingDistance,
        ExplosionDamage,
        ExplosionCooldown,
        ExplosionArea
    }
}

