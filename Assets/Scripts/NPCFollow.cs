using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float stopDistance = 1.2f;

    Rigidbody2D rb;
    Animator anim;
    Vector2 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 offset = (Vector2)player.position - rb.position;

        if (offset.magnitude > stopDistance)
        {
            direction = offset.normalized;
            rb.MovePosition(rb.position +
                direction * speed * Time.fixedDeltaTime);
        }
        else
        {
            direction = Vector2.zero;
        }

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetFloat("Speed", direction.sqrMagnitude);
    }
}