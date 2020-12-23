﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Serialized
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float walkForce = 1f;
    [SerializeField] private float raycastDown = 2.1f;

    // Private
    Vector3 walk;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Jump();
        walk.x = Input.GetAxisRaw("Horizontal");
        walk.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        if (CanJump())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool CanJump()
    {
        return Input.GetKeyDown(KeyCode.Space) && IsFloored();
    }

    bool IsFloored()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDown);
    }

    void Move()
    {
        var newDir = new Vector3(walk.x, 0, walk.z) * walkForce * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + rb.transform.TransformDirection(newDir));

    }
}
