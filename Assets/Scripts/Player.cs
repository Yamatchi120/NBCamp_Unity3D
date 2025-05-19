using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
        controller.Player = this;
        controller = GetComponent<PlayerController>();
    }
}
