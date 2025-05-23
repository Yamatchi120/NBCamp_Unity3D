using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image hpFillImg;
    [SerializeField] private Text timeTxt;

    PlayerController playerController;
    //public Image hpBar;

    float fillAmount;
    float sec;
    int min;
    private void Start()
    {
        playerController = GameManager.Instance.PlayerController;
    }
    private void Update()
    {
        fillAmount = SetHp();
        TimeTxt();
        //hpBar.fillAmount = SetHp();
    }
    public float SetHp()
    {
        fillAmount = playerController.CurrentHp / playerController.MaxHp;

        if (hpFillImg != null)
            hpFillImg.fillAmount = fillAmount;

        return fillAmount;
    }
    public void TimeTxt()
    {
        sec += Time.deltaTime;

        if(sec >= 60f)
        {
            min += 1;
            sec = 0;
        }
        timeTxt.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }

}
