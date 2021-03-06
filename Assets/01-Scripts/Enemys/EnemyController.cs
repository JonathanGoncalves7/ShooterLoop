using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] int goldOnDie;
    [SerializeField] GameObject HitVFX;

    public EnemyState State;

    Health _health;
    Collider _collider;
    NavMeshAgent _navMeshAgent;

    EnemyAnimations _enemyAnimations;
    EnemyAttack _enemyAttack;
    EnemyMovement _enemyMovement;

    GameObject _player;
    PlayerStatusSO _playerStatusSO;

    private void Start()
    {
        _health = GetComponent<Health>();
        _collider = GetComponent<Collider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyMovement = GetComponent<EnemyMovement>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStatusSO = _player.GetComponent<PlayerController>().PlayerStatus;

        UpdateState(EnemyState.Idle);
    }

    private void Update()
    {
        if (State == EnemyState.Die)
        {
            return;
        }
        else if (GameManager.s_instance.State != GameState.PlayingWave)
        {
            UpdateState(EnemyState.Idle);
        }
        else if (!_enemyMovement.ReachedTarget(_player.transform.position))
        {
            UpdateState(EnemyState.Move);
        }
        else if (_enemyAttack.CanAttack(_player.transform.position))
        {
            UpdateState(EnemyState.Attack);
        }
    }

    public void Damage(int damage)
    {
        _health.CurrentHealth -= damage;

        ShowHitVFX();
        UIManager.s_instance.ShowDamagePopup(damage, transform.position);

        if (_health.CurrentHealth <= 0)
        {
            UpdateState(EnemyState.Die);
        }
    }

    private void ShowHitVFX()
    {
        GameObject newVFX = Instantiate(HitVFX, transform.position, Quaternion.identity);
        Destroy(newVFX, 1);
    }

    public void UpdateState(EnemyState newState)
    {
        State = newState;

        switch (State)
        {
            case EnemyState.Idle:
                _enemyAnimations.UpdateSpeed(0);
                _enemyMovement.Stop();
                break;

            case EnemyState.Move:
                _enemyMovement.MoveToTarget(_player.transform.position);
                _enemyAnimations.UpdateSpeed(_navMeshAgent.velocity.magnitude);
                break;

            case EnemyState.Attack:
                _enemyAnimations.UpdateSpeed(0);
                _enemyAnimations.Attack();

                _enemyMovement.Stop();

                _enemyAttack.Attack(_playerStatusSO, _player.transform.position);
                break;

            case EnemyState.Die:
                _collider.enabled = false;

                _enemyMovement.Stop();

                _enemyAnimations.UpdateSpeed(0);
                _enemyAnimations.Die();

                GameManager.s_instance.GoldData.Inc(goldOnDie);

                Destroy(gameObject, 3);
                break;
        }
    }
}