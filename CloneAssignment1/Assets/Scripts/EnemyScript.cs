using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public float health;
    public float maxHealth = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth; 
    }

    // Update is called once per frame
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
<<<<<<< Updated upstream
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
=======
            if (isRepelled)
            {
                rb.linearVelocity = repelDirection * moveSpeed;
            }
            else
            {
                rb.linearVelocity = moveDirection * moveSpeed;
            }
>>>>>>> Stashed changes
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
