using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image hpFillImg;
    PlayerController playerController;
    private void Start()
    {
        playerController = GameManager.Instance.PlayerController;
    }
    public void SetHp()
    {
        float fillAmount = playerController.CurrentHp / playerController.MaxHp;

        if (hpFillImg != null)
            hpFillImg.fillAmount = fillAmount;
    }
}
