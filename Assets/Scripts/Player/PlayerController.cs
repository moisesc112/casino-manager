using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private Vector3 _targetMovement;
    private Vector3 _velocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _currentMovement = _targetMovement;
    }

    void Update()
    {
        _currentMovement = _targetMovement;
        HandleMove();
        HandleJump();
    }
    public void MoveInput(Vector2 moveInput)
    {
        _targetMovement.x = moveInput.x * _moveSpeed;
        _targetMovement.z = moveInput.y * _moveSpeed;
    }

    public void JumpInput()
    {
        if (_characterController.isGrounded)
            _velocity.y = Mathf.Sqrt(-2f * _gravity * _jumpForce);   
    }

    void HandleMove()
    {
        _characterController.Move(_currentMovement * Time.deltaTime);
    }

    void HandleJump()
    {
        if (_characterController.isGrounded && _velocity.y < 0f)
            _velocity.y = _gravity;

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

}
