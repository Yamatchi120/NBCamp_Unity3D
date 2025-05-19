using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerController playerController;

    [Header("Movement")]
    public float moveSpeed;
    Vector2 currentMoveInput;

    private Rigidbody _rb;

    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = transform.forward * currentMoveInput.y + transform.right * currentMoveInput.x;
        dir *= moveSpeed;
        dir.y = _rb.velocity.y;

        _rb.velocity = dir;
    }
    void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            currentMoveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            currentMoveInput = Vector2.zero;
        }
    }
}
