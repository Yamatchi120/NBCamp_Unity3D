using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float baseSpeed;

    float moveX;
    float moveZ;

    Vector2 movement;
    Vector3 currentMove;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        //GetInput();
        Move();
    }

    //private void GetInput()
    //{
    //    moveX = Input.GetAxisRaw("Horizontal");
    //    moveZ = Input.GetAxisRaw("Vertical");
    //}
    //private void Move()
    //{
    //    movement = new Vector3(moveX, 0, moveZ);
    //    transform.Translate(movement * Time.deltaTime * baseSpeed);
    //}
    void Move()
    {
        Vector3 dir = transform.forward * currentMove.y +
                      transform.right * currentMove.x;
        dir *= baseSpeed;
        dir.y = _rb.velocity.y;

        _rb.velocity = dir;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            currentMove = context.ReadValue<Vector2>();
        else if(context.phase == InputActionPhase.Canceled)
            currentMove = Vector2.zero;
    }
}
