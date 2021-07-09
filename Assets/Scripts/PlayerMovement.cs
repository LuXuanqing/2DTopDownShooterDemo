using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    private Vector2 movement;

    // references
    private Animator animator;
    private Rigidbody2D rb;


    private void Awake()
    {
        // get references
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    private void HandleInput()
    {
        // move
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void HandleMovement()
    {
        // move player
        // method 1: movePosition
        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
        // // method 2: velocity
        // rb.velocity = movement.normalized * speed;

        // change animation
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }
}
