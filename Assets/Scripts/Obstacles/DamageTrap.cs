using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        // SpikeTrap���� IDamage�� ������
        // GetComponent<IDamage>���ؼ� IDamage�� �پ��ִ� 
        // ��ũ��Ʈ�� �ҷ��� �� ���� ( PlayerController )
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null) damageable.TakeDamage(damageAmount);
    }
}
