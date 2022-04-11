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

    public void Attack(IDamaged target)
    {
        int damage = Damage.GetRandom();
        target.Damage(damage);

        _lastAttack = Time.time + AttackRate;
    }
}
