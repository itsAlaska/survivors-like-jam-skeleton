using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public static PlayerInputHandler Instance { get; private set; }

    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;

    public Vector2 MoveInput => _moveInput;

    private void Awake()
    {
        // Singleton pattern for easy access
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _inputActions = new PlayerInputActions();
        _inputActions.Player.Enable();

        // Subscribe to movement input
        _inputActions.Player.Movement.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Movement.canceled += _ => _moveInput = Vector2.zero;
    }

    private void OnDestroy()
    {
        // Clean up listeners to avoid memory leaks
        _inputActions.Player.Movement.performed -= ctx => _moveInput = ctx.ReadValue<Vector2>();
        _inputActions.Player.Movement.canceled -= _ => _moveInput = Vector2.zero;
    }
}