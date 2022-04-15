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
        var currentSpeed = GetSpeed();

        if (Direction.x > 0 && Direction.z > 0)
        {
            currentSpeed /= 2;
        }

        Debug.Log(PowerupSpeed.GetBonus(Speed));
        Debug.Log(currentSpeed);

        _rigidbody.velocity = Direction * currentSpeed;
    }

    private float GetSpeed()
    {
        return Speed + PowerupSpeed.GetBonus(Speed);
    }
}
