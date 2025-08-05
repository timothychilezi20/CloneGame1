using UnityEngine;

public class EnemySpawnerVampireStyle : MonoBehaviour
{
    [Header("References")]
    public Transform player;                   // Player to spawn enemies around
    public GameObject[] enemyPrefabs;          // Enemy types to spawn

    [Header("Spawn Settings")]
    public float spawnRadius = 15f;            // How far from the player enemies appear
    public float startSpawnInterval = 2f;      // Initial time between spawns
    public float minSpawnInterval = 0.2f;      // Fastest spawn rate possible
    public float difficultyRamp = 0.01f;       // How quickly spawn rate decreases over time

    [Header("Enemy Tier Settings")]
    public float tier2Time = 60f;              // Time when stronger enemies appear
    public float tier3Time = 120f;             // Even stronger enemies

    private float spawnTimer;
    private float currentSpawnInterval;
    private float elapsedTime;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        // Spawn enemy when timer reaches 0
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = currentSpawnInterval;
        }

        // Gradually ramp up difficulty (reduce spawn interval)
        currentSpawnInterval = Mathf.Max(
            minSpawnInterval,
            currentSpawnInterval - difficultyRamp * Time.deltaTime
        );
    }

    void SpawnEnemy()
    {
        if (player == null || enemyPrefabs.Length == 0) return;

        // Pick enemy type based on elapsed time
        GameObject enemyToSpawn = GetEnemyByTime();

        // Random position around player
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnRadius;

        // Create enemy
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

        // Give enemy a reference to the player so it can chase
        EnemyFollowPlayer followScript = newEnemy.GetComponent<EnemyFollowPlayer>();
        if (followScript != null)
        {
            followScript.player = player;
        }
    }

    GameObject GetEnemyByTime()
    {
        if (elapsedTime >= tier3Time && enemyPrefabs.Length >= 3)
            return enemyPrefabs[Random.Range(0, 3)];
        else if (elapsedTime >= tier2Time && enemyPrefabs.Length >= 2)
            return enemyPrefabs[Random.Range(0, 2)];
        else
            return enemyPrefabs[0];
    }
}


// Spawn enemy when timer reaches 0
