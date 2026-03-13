using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed;
    [SerializeField]
    private float _playerJumpForce;
    [SerializeField]
    private float _playerDashForce;

    private PlayerActions _inputActions;
    private Rigidbody2D _rb;

    private Vector2 _moveDirection;

    void Awake()
    {
        _inputActions = new PlayerActions();

        if (TryGetComponent<Rigidbody2D>(out var component))
            _rb = component;
    }

    private void Start()
    {
        _inputActions.PlayerMovement.Jump.performed += Jump;
        _inputActions.PlayerMovement.Dash.performed += Dash;
    }

    private void FixedUpdate()
    {
        _moveDirection = _inputActions.PlayerMovement.Move.ReadValue<Vector2>();

        // Movimento com Transform
        transform.Translate(_playerSpeed * Time.deltaTime * _moveDirection);

        // Movimento com RigidBody2D
        //_rb.AddForce(_moveDirection * _playerSpeed, ForceMode2D.Force);
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    // Caso jogo tenha pulo
    private void Jump(InputAction.CallbackContext ctx) 
    {
        _rb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
    }
    
    // Caso jogo tenha Dash
    private void Dash(InputAction.CallbackContext ctx)
    {
        _rb.AddForce(_moveDirection * _playerJumpForce, ForceMode2D.Impulse);
    }
}
    