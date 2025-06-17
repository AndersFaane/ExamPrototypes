using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperties : MonoBehaviour
{
    //public Text killCountUI;

    //private int killCount;

    public PlayerHealth playerHealth;

    [SerializeField] private float enemyHealth;
    
    public float enemyDamage;

    public Material normalMaterial;

    public Material flashMaterial;

    private float timer;

    public float flashTimer;

    [Header("Loot")]
    public List<LootItem> lootTable = new List<LootItem>();

    //Runs if enemy is hit by ranged projectile.
    public void enemyTakeDamage(float bulletDamage)
    {
        
        enemyHealth -= bulletDamage;
        

        //If enemy's health reaches 0, drop loot based on the chance persentage defined in the editor.
        if (enemyHealth <= 0f)
        {
            foreach(LootItem lootItem in lootTable)
            {
                if(Random.Range(0f, 100f) <= lootItem.dropChance)
                {
                    InstantiateLoot(lootItem.ItemPrefab);
                }
                break;
            }
            Destroy(gameObject);

            //killCount++;
        }
    }

    //If gameobject with the "Player" tag enters the trigger zone of the enemy, run the PlayerTakeDamage method in the PlayerHealth script subtracting the enemyDamage defined in this script.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(enemyDamage);
            Debug.Log("Player Damaged");
        }
    }

    void InstantiateLoot(GameObject loot)
    {
        //If the enemy drops loot, it drops at the exact point where the enemy died.
        if (loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);

            //droppedLoot.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
