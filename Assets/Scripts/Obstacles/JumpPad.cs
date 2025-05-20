using System.Collections;
using System.Collections.Generic;
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
        player.Rb.AddForce(Vector3.up * obstacleJumpPower);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("jump");
            anim.SetBool("isJumpPadActivate", true);
            OnJumpPad();

        }
    }
}
