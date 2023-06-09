using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerCombat;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static event EventHandler<IsMovingEventArgs> IsMoving;

    public class IsMovingEventArgs : EventArgs
    {
        public bool isMoving;
    }

    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveX == 0f && moveY == 0)
        {
            IsMoving?.Invoke(this, new IsMovingEventArgs { isMoving = false });
        }
        else
        {
            IsMoving?.Invoke(this, new IsMovingEventArgs { isMoving = true });
            print("Moving");
        }
    }
}