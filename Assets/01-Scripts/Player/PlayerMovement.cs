using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] PowerupDataSO PowerupSpeed;

    public Vector3 Direction;
    Rigidbody _rigidbody;
    Collider _collider;
    PlayerStatusSO _playerStatus;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _playerStatus = GetComponent<PlayerController>().PlayerStatus;
    }

    private void Update()
    {
        SetDirection();
    }

    private void SetDirection()
    {
        Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (NextPositionValid() && GameManager.s_instance.State == GameState.PlayingWave)
            _rigidbody.velocity = Direction.normalized * GetSpeed();
        else
            _rigidbody.velocity = Vector3.zero;
    }

    private bool NextPositionValid()
    {
        Vector3 newPosition = _rigidbody.position + Direction.normalized * Time.fixedDeltaTime * GetSpeed();

        return Physics.Raycast(newPosition, Vector3.down, _collider.bounds.extents.y);
    }

    private float GetSpeed()
    {
        return Speed + PowerupSpeed.GetBonus(Speed);
    }
}
