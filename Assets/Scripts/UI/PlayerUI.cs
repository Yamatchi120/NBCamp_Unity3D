using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image hpFillImg;
    PlayerManager playerManager;
    private void Start()
    {
        playerManager = GameManager.Instance.PlayerManager;
    }
    public void SetHp(float currentHp, float maxHp)
    {
        float fillAmount = currentHp / maxHp;

        if (hpFillImg != null)
            hpFillImg.fillAmount = fillAmount;
    }
}
