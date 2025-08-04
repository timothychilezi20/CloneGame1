using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health;
    public float maxHealth = 3f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    
    public bool isRepelled = false;
    public Vector2 repelDirection;
    public GameObject lifeGemPrefab;
    public GameObject bloodEffect;
    public GameObject points; 

    private XPManager xpManager;

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

            if (health <= 0)
            {
                if (bloodEffect != null)
                {
                    GameObject blood = Instantiate(bloodEffect, transform.position, Quaternion.identity);
                    Destroy(blood, 2f);
                }
            }

            if (points != null)
            {
                GameObject popUp = Instantiate(points, transform.position, Quaternion.identity);
                Destroy(popUp, 1f);
                Debug.Log("XP Added");
                
            }

            XPManager xpManager = FindObjectOfType<XPManager>();
            if (xpManager != null)
            {
                xpManager.addXPPoints(5);
            }


            if (lifeGemPrefab != null)
          {
            Instantiate(lifeGemPrefab, transform.position, Quaternion.identity);
          }

          Destroy(gameObject);
         

        }
    }
}
