using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    public float jumpHeight; 
    public Animator animator;
    public GameObject Melee; 
    public Transform aim;
    private bool isAttacking = false;
    float attackDuration = 0.3f;
    float attackTimer = 0f;

    public GameObject projectile;
    public float fireForce = 10f;
    float shootCooldown = 0.25f;
    float shootTimer = 0.5f; 

    private Vector2 lastInputDirection; 

    private bool isWalking = false; 

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.GetComponent<Animator>(); 
    }

    void Update()
    {
        rigidBody.velocity = moveInput * moveSpeed;
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * moveInput.x + Vector3.down * moveInput.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }

        CheckMeleeTimer();
        shootTimer += Time.deltaTime; 
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);
        isWalking = true; 

        if(context.canceled)
        {
            animator.SetBool("isWalking", false); 
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            isWalking = false;
            lastInputDirection = moveInput; 
            Vector3 vector3 = Vector3.left * lastInputDirection.x + Vector3.down * lastInputDirection.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput .y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        animator.SetBool("isJumping", true);

        if (context.canceled)
        {
            animator.SetBool("isJumping", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

    }

    public void Attack(InputAction.CallbackContext context)
    {

        Melee.SetActive(true);
        isAttacking = true; 
        animator.SetBool("isAttacking", true);

        if (context.canceled)
        {
            animator.SetBool("isAttacking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
    }

    private void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime; 
            if(attackTimer >= attackDuration)
            {
                attackTimer = 0;
                isAttacking= false;
                Melee.SetActive(false);
            }
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            GameObject intProjectile = Instantiate(projectile, aim.position, aim.rotation);
            intProjectile.GetComponent<Rigidbody2D>().AddForce(-aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intProjectile, 2f); 
        }
    }
}
