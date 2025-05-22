using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10.0f;

    PlayerController playerController;
    private void Start()
    {
        playerController = GameManager.Instance.PlayerManager.PlayerController;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger");
        // SpikeTrap에는 IDamage가 없지만
        // GetComponent<IDamage>를해서 IDamage가 붙어있는 
        // 스크립트를 불러올 수 있음 ( PlayerController )
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null) damageable.TakeDamage(damageAmount);
    }
}
