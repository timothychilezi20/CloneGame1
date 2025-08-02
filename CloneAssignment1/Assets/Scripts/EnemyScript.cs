using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health;
    public float maxHealth = 3f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    // 👇 Add this
    public bool isRepelled = false;
    public Vector2 repelDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (isRepelled)
            {
                rb.velocity = repelDirection * moveSpeed;
            }
            else
            {
                rb.velocity = moveDirection * moveSpeed;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
