using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private float TrapDamage = 10.0f;

    PlayerController playerController;
    private void Start()
    {
        playerController = GameManager.Instance.PlayerManager.PlayerController;
    }
    void OnDamage()
    {
        playerController.CurrentHp -= TrapDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger");
        if (other.CompareTag("Player")) OnDamage();
    }
}
