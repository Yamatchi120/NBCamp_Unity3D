using UnityEngine;

public class UIManager : MonoBehaviour
{
    private PlayerUI playerUI;
    public PlayerUI PlayerUI => playerUI;
    public void Init()
    {
        playerUI = FindObjectOfType<PlayerUI>();
    }
}
