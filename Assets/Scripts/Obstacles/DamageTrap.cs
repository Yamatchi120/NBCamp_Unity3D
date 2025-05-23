using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        // SpikeTrap에는 IDamage가 없지만
        // GetComponent<IDamage>를해서 IDamage가 붙어있는 
        // 스크립트를 불러올 수 있음 ( PlayerController )
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null) damageable.TakeDamage(damageAmount);
    }
}
