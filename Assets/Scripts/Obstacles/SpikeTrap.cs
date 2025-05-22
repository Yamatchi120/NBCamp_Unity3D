using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10.0f;

    private void Start()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        // SpikeTrap���� IDamage�� ������
        // GetComponent<IDamage>���ؼ� IDamage�� �پ��ִ� 
        // ��ũ��Ʈ�� �ҷ��� �� ���� ( PlayerController )
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null) damageable.TakeDamage(damageAmount);
    }
}
