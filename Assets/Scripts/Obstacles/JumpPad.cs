using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Animator anim;
    
    [SerializeField] private float obstacleJumpPower;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IJump jumper = collision.gameObject.GetComponent<IJump>();
            if (jumper != null) jumper.Jump(Vector3.up, obstacleJumpPower);

            anim.SetBool("isJumpPadActivate", true);

            StartCoroutine(ResetJumpPad());
        }
    }

    IEnumerator ResetJumpPad()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("isJumpPadActivate", false);
    }
}
