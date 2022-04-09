using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimations : MonoBehaviour
{
    Animator _animator;
    PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float velocityX = Vector3.Dot(_playerMovement.Direction, transform.right);
        float velocityZ = Vector3.Dot(_playerMovement.Direction, transform.forward);

        _animator.SetFloat("Speed X", velocityX, 0.1f, Time.deltaTime);
        _animator.SetFloat("Speed Z", velocityZ, 0.1f, Time.deltaTime);
    }
}
