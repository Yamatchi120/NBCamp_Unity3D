using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController playerController;
    public PlayerController PlayerController => playerController;
    public Rigidbody PlayerRb => playerController.Rb;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
}
