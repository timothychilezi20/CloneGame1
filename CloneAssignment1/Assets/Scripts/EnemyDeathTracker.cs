using UnityEngine;

public class EnemyDeathTracker : MonoBehaviour
{
    public EnemySpawner spawner;

    private EnemyScript enemyScript;

    private void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
    }

    private void Update()
    {
        if (enemyScript != null && enemyScript.health <= 0)
        {
            spawner.OnEnemyKilled();
           
            Destroy(this); // Prevents calling multiple times
        }
    }
}
