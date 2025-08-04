using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;          
    public int numberToSpawn = 5;            
    public List<Transform> spawnPoints;      

    private int enemiesAlive;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyDeathTracker>().spawner = this;
            enemiesAlive++;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            Debug.Log("All enemies defeated! You win!");
        }
    }
}
