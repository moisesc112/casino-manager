using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private Vector3 _targetMovement;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _currentMovement = _targetMovement;
    }

    void Update()
    {
        _currentMovement = _targetMovement;
        HandleJump();
        HandleMove();
    }
    public void MoveInput(Vector2 moveInput)
    {
        _targetMovement.x = moveInput.x * _moveSpeed;
        _targetMovement.z = moveInput.y * _moveSpeed;
    }

    public void JumpInput()
    {
        if (_characterController.isGrounded)
        {
            _targetMovement.y = Mathf.Sqrt(-2f * _gravity * _jumpForce);
        }
    }

    void HandleMove()
    {
        _characterController.Move(_currentMovement * Time.deltaTime);
    }

    void HandleJump()
    {
        if (_targetMovement.y < 0)
            _targetMovement.y = 0;

        _targetMovement.y += _gravity * Time.deltaTime;
    }

}
