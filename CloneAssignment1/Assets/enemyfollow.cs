using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;   // Assigned by the spawner
    public float moveSpeed = 2f;

    void Update()
    {
        if (player == null) return;

        // Move toward the player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }
}

