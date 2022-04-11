using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = transform.GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        int randomIndex = Random.Range(0, 1);

        if (randomIndex == 0)
        {
            _animator.SetTrigger("Attack 01");
        }
        else
        {
            _animator.SetTrigger("Attack 02");
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
    }

    public void UpdateSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
