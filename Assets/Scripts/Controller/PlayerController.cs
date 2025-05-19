using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    float baseSpeed = 5f;

    float moveX;
    float moveZ;

    Vector3 movement;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * Time.deltaTime * baseSpeed);
    }

}
