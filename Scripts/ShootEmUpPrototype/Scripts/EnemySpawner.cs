using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    private int enemyCount;
    public int maxEnemyCount;
    public int newMaxEnemyCount;
    public float timeToSpawn;
    private float spawnCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCounter = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0 && enemyCount < maxEnemyCount)
        {
            spawnCounter = timeToSpawn;

            Instantiate(enemyToSpawn, transform.position, transform.rotation);
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Debug.Log("Enemy count: " + enemyCount);

        if (enemyCount == maxEnemyCount)
        {
            StartCoroutine(SpawnMoreEnemies());
        }

        
    }

    IEnumerator SpawnMoreEnemies()
    {
        yield return new WaitForSeconds(10);
        maxEnemyCount = newMaxEnemyCount;
    }


}