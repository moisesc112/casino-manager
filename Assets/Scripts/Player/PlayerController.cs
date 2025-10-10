using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _mouseSensitivity = 0.05f;
    [SerializeField] private Transform _cameraTransform;

    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private Vector3 _targetMovement;
    private Vector3 _velocity;

    private float _pitch;
    private float _yaw;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMove();
        HandleJump();
        HandleRotation();
    }
    public void MoveInput(Vector2 moveInput)
    {
        _targetMovement.x = moveInput.x;
        _targetMovement.z = moveInput.y;
    }

    public void JumpInput()
    {
        if (_characterController.isGrounded)
            _velocity.y = Mathf.Sqrt(-2f * _gravity * _jumpForce);   
    }

    public void RotationInput(float mouseX, float mouseY)
    {
        mouseX *= _mouseSensitivity;
        mouseY *= _mouseSensitivity;

        _pitch -= mouseY;
        _yaw += mouseX;

        _pitch = Mathf.Clamp(_pitch, -90f, 90f);
    }

    private void HandleMove()
    {
        var moveLocal = new Vector3(_targetMovement.x, 0f, _targetMovement.z);
        _currentMovement = (transform.right * moveLocal.x + transform.forward * moveLocal.z).normalized;

        _characterController.Move(_currentMovement * _moveSpeed * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (_characterController.isGrounded && _velocity.y < 0f)
            _velocity.y = _gravity;

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void HandleRotation()
    {
        transform.rotation = Quaternion.Euler(0f, _yaw, 0f);

        if (_cameraTransform != null)
            _cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);

    }
}
