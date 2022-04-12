using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] MinAndMax Damage;
    [SerializeField] float AttackRange;
    [SerializeField] float AttackRate;

    float _lastAttack;

    private void Start()
    {
        _lastAttack = Time.time + AttackRate;
    }

    public bool CanAttack(Vector3 tagetPosition)
    {
        return (Vector3.Distance(tagetPosition, transform.position) <= AttackRange && Time.time >= _lastAttack);
    }

    public void Attack(PlayerStatusSO target, Vector3 damagePosition)
    {
        int damage = Damage.GetRandom();
        target.Damage(damage, damagePosition);

        _lastAttack = Time.time + AttackRate;
    }
}
