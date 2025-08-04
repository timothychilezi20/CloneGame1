using UnityEngine;

public class SafeHouseZone : MonoBehaviour
{
    public float repelForceMultiplier = 1.5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.isRepelled = true;
                enemy.repelDirection = (other.transform.position - transform.position).normalized * repelForceMultiplier;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.isRepelled = false;
            }
        }
    }
}
