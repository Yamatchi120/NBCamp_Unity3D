using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image hpFillImg;

    public void SetHp(float currentHp, float maxHp)
    {
        float fillAmount = currentHp / maxHp;

        if (hpFillImg != null)
            hpFillImg.fillAmount = fillAmount;
    }
}
