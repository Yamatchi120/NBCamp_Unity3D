using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    PlayerManager playerManager;
    //Animator anim;
    
    [SerializeField] private float obstacleJumpPower = 15f;
    private void Awake()
    {

    }
    private void Start()
    {
        playerManager = GameManager.Instance.PlayerManager;
        //anim = GetComponent<Animator>();
    }
    public void OnJumpPad()
    {
        playerManager.PlayerRb.AddForce(Vector3.up * obstacleJumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //anim.SetBool("isJumpPadActivate", true);
            OnJumpPad();
            //StartCoroutine(ResetJumpPad());
        }
    }

    //IEnumerator ResetJumpPad()
    //{
    //    yield return new WaitForSeconds(3f);
    //    anim.SetBool("isJumpPadActivate", false);
    //}
}
