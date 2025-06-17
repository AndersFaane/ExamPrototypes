using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healingAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerHealth>().health += healingAmount;
            Debug.Log("Player Healed");
        }
    }
}
