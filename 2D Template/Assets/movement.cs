using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]  // this script can only be added to a gameobject with a rigidbody2d

public class movement : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveAmount;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocityX = _moveAmount.x;
    }

    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        _moveAmount = ctx.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext ctx)
    {
        _rb.linearVelocityY = 10;
    }
}
