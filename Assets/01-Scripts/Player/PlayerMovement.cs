using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] PowerupDataSO PowerupSpeed;

    public Vector3 Direction;
    Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetDirection();
    }

    private void SetDirection()
    {
        Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Direction * GetSpeed();
    }

    private float GetSpeed()
    {
        return Speed + PowerupSpeed.GetBonus(Speed);
    }
}
