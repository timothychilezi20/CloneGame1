using UnityEngine;

public class EnemySafeZoneRepel : MonoBehaviour
{
    public Transform zoneCenter;
    public float repelForce = 10f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (zoneCenter == null) return;

        Vector2 repelDirection = (rb.position - (Vector2)zoneCenter.position).normalized;
        rb.linearVelocity = repelDirection * repelForce;
    }
}
