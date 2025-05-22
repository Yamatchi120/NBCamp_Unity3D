using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamage, IJump
{
    [Header("Movement")]
    public float baseSpeed;
    Vector3 currentMove;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    private float baseJumpPower = 15f;
    public float BaseJumpPower
    {
        get { return baseJumpPower; }
        set { baseJumpPower *= value; }
    }
    private float currentHp;
    public float CurrentHp
    {
        get { return currentHp; }
        set { currentHp = value; }
    }
    private float maxHp = 100.0f;
    public float MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    public Rigidbody Rb { get; private set; }
    Animator anim;

    private void Awake()
    {
        
    }
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        currentHp = maxHp;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {

    }
    private void LateUpdate()
    {
        CameraLook();
    }

    void Move()
    {
        Vector3 dir = transform.forward * currentMove.y +
                      transform.right * currentMove.x;
        dir *= baseSpeed;
        dir.y = Rb.velocity.y;

        Rb.velocity = dir;
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            currentMove = context.ReadValue<Vector2>();
            anim.SetBool("isRun", true);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            currentMove = Vector2.zero;
            anim.SetBool("isRun", false);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && isGrounded())
        {
            Rb.AddForce(Vector2.up * baseJumpPower, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
        }
    }
        
    bool isGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        Debug.Log($"데미지 : {amount}\n현재 HP : {currentHp}/{maxHp}");
    }
    public void Jump(Vector3 direction, float power)
    {
        Rb.AddForce(direction * power, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundObj"))
        {
            anim.SetBool("isJump", false);
        }
    }

}
