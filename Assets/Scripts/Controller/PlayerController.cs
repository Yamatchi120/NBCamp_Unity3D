using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseStatus, IDamage, IJump, IHeal
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

    [SerializeField] private float rayLength;
    public Rigidbody Rb { get; private set; }
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        DrawGroundCheckRay();
    }
    private void FixedUpdate()
    {
        Move();
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
            Jump(Vector3.up, BaseJumpPower);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
        }
    }
        
    void ObjInfo()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 
                out RaycastHit hit, 1f))
        {
            string objName = hit.collider.name; // 오브젝트 이름
            string tagName = hit.collider.tag; // 태그 이름
            GameObject hitObj = hit.collider.gameObject; // 오브젝트 전체 참조

            Debug.DrawRay();
            Debug.Log($"대상 : {objName}, 태그 : {tagName}");
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

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
    void DrawGroundCheckRay()
    {
        Vector3[] origins = new Vector3[4]
        {
        transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f),
        transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f),
        transform.position + (transform.right * 0.2f) + (transform.up * 0.01f),
        transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f)
        };

        for (int i = 0; i < origins.Length; i++)
        {
            Debug.DrawRay(origins[i], Vector3.down * rayLength, Color.red);
        }
    }

    public void TakeDamage(float amount)
    {
        CurrentHp -= amount;
        GameManager.Instance.UIManager.PlayerUI.SetHp();
        Debug.Log($"데미지 : {amount}\n현재 HP : {CurrentHp}/{MaxHp}");
    }
    public void Jump(Vector3 direction, float power)
    {
        Rb.AddForce(direction * power, ForceMode.Impulse);
    }
    public void Heal(float amount)
    {
        CurrentHp += amount;
        GameManager.Instance.UIManager.PlayerUI.SetHp();
        Debug.Log($"회복량 : {amount}\n현재 HP : {CurrentHp}/{MaxHp}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundObj"))
        {
            anim.SetBool("isJump", false);
        }
    }

}
