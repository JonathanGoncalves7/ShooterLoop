using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveSO", menuName = "ShooterLoop/EnemyWaveSO", order = 0)]
public class EnemyWaveSO : ScriptableObject
{
    public GameObject prefab;
    [Range(0, 1)] public float PercentageRespawn;
    public int StartWave;
    public int EndWave;
    public int Gold = 5;
}