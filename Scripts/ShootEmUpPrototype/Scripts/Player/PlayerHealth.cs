using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private float maxHealth;
    public Image healthBar;

    public GameObject Spawners;

    private bool isDead;

    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        
        //Show game over screen and disbales the player gameobject if players health is 0 or less as long as the player isnt already dead.
        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            Spawners.gameObject.SetActive(false);
            gameManager.gameOver();
            Debug.Log("Dead");
        }
    }

    public void PlayerTakeDamage(float enemyDamage)
    {
        health -= enemyDamage;
    }

    void Heal(int amount)
    {
        //Adds defined amount to players health.
        //If players health is already full then set it to max health to avoid going over the max health.
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    
}
