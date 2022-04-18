using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDataSO", menuName = "ShooterLoop/ProjectileDataSO", order = 0)]
public class ProjectileDataSO : ScriptableObject
{
    public GameObject Prefab;
    public float Speed;
    public MinAndMax Damage;
    public float LifeTime;
    public float RadiusDamage;
}