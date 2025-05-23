using UnityEngine;

public class HpPosition : MonoBehaviour 
{
    [SerializeField] private float healAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IHeal heal = other.gameObject.GetComponent<IHeal>();
            if (heal != null)
            {
                heal.Heal(healAmount);
                Destroy(gameObject);

            }
        }
    }
}
