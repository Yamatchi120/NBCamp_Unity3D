using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    PlayerController player;
    Animator anim;

    private float obstacleJumpPower = 20f;
    private void Start()
    {
        player = GameManager.Instance.PlayerController;
        anim = GetComponent<Animator>();
    }
    public void OnJumpPad()
    {
        player.Rb.AddForce(Vector3.up * obstacleJumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isJumpPadActivate", true);
            OnJumpPad();
            StartCoroutine(ResetJumpPad());
        }
    }

    IEnumerator ResetJumpPad()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("isJumpPadActivate", false);
    }
}
