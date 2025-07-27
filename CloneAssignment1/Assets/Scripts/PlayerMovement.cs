using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    public float jumpHeight; 
    public Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.GetComponent<Animator>(); 
    }

    void Update()
    {
        rigidBody.velocity = moveInput * moveSpeed; 
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if(context.canceled)
        {
            animator.SetBool("isWalking", false); 
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);  
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
        animator.SetBool("isAttacking", true);

        if (context.canceled)
        {
            animator.SetBool("isAttacking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
    }
}
