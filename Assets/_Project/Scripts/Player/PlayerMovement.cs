using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{   
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 10f;
    
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 input = PlayerInputHandler.Instance.MoveInput;
        Vector2 velocity = input.normalized * _moveSpeed;
        
        _rb.velocity = velocity;
    }
}
