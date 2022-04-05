using UnityEngine;

[System.Serializable]
public class MinAndMax
{
    public int Min;
    public int Max;

    public int GetRandom()
    {
        return Random.Range(Min, Max);
    }
}
