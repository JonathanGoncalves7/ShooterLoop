using UnityEngine;

public class PiercingProjectileBehavior : ProjectileBehavior
{
    public int MaxTargetDamaged;
    int _targetDamaged;

    private new void Start()
    {
        base.Start();

        _targetDamaged = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Enemy"))
        {
            BasicDamage(other.gameObject);
            _targetDamaged++;
        }
        else
        {
            Destroy(gameObject);
        }

        if (_targetDamaged >= MaxTargetDamaged)
            Destroy(gameObject);
    }
}
