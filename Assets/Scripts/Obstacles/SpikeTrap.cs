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
        // SpikeTrap���� IDamage�� ������
        // GetComponent<IDamage>���ؼ� IDamage�� �پ��ִ� 
        // ��ũ��Ʈ�� �ҷ��� �� ���� ( PlayerController )
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null) damageable.TakeDamage(damageAmount);
    }
}
