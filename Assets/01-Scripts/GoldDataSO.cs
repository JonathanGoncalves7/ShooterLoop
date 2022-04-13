using UnityEngine;

[CreateAssetMenu(fileName = "GoldDataSO", menuName = "ShooterLoop/GoldDataSO", order = 0)]
public class GoldDataSO : ScriptableObject
{
    private const string GOLD = "GOLD";

    [SerializeField] int GoldAmount;

    private void OnEnable()
    {
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt(GOLD, GoldAmount);
    }

    public void Load()
    {
        GoldAmount = PlayerPrefs.GetInt(GOLD, 0);
    }

    public void Inc(int value)
    {
        GoldAmount += value;

        Save();
    }

    public void Dec(int value)
    {
        GoldAmount = Mathf.Max(GoldAmount - value, 0);

        Save();
    }

    public int GetAmount()
    {
        return GoldAmount;
    }
}