using UnityEngine;

[System.Serializable]
public class FloatMinAndMax
{
    public float Min;
    public float Max;

    public float GetRandom()
    {
        return Random.Range(Min, Max);
    }
}
