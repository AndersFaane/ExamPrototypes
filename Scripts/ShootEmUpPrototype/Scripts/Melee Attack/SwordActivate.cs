using UnityEngine;

public class SwordActivate : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] public float damage;

   
    //Trigger on sword gameobject only affects other gameobjects with "Enemy" tag.
    //If an "Enemy" enters trigger it runs a method in EnemyProperties script that subtracts the damage variable in this script from the enemy health in the EnenmyProperties script.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isActive == true)
        {
            other.GetComponent<EnemyProperties>().enemyTakeDamage(damage);
            Debug.Log("Enemy Hit(Sword)");
        }

    }
}
