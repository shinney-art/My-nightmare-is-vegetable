using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 movement;
    private Vector2 lastMoveDirection = Vector2.right;

    void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (anim == null)
            anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Read player input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Store input in movement
        movement = new Vector2(horizontal, vertical).normalized;

        bool isWalking = movement.sqrMagnitude > 0.01f;

        // Remember the last direction
        if (isWalking)
        {
            lastMoveDirection = movement;
        }

        // Update animation parameters
        anim.SetBool("isWalking", isWalking);

        anim.SetFloat("InputX", movement.x);
        anim.SetFloat("InputY", movement.y);

        anim.SetFloat("LastInputX", lastMoveDirection.x);
        anim.SetFloat("LastInputY", lastMoveDirection.y);
    }

    void FixedUpdate()
    {
        // Move player using physics
        rb.velocity = movement * moveSpeed;
    }
}
