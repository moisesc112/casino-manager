using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>(); 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var moveInput = context.ReadValue<Vector2>();
        if (_playerController)
            _playerController.MoveInput(moveInput);
        else
            Debug.LogError("Player Controller is Null");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_playerController)
            _playerController.JumpInput();
        else
            Debug.LogError("Player Controller is Null");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        var lookInput = context.ReadValue<Vector2>();

        if (_playerController)
            _playerController.RotationInput(lookInput.x, lookInput.y);
        else
            Debug.LogError("Player Controller is Null");
    }
}
