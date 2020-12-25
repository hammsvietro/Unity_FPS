using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Serialized
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float walkForce = 1f;
    [SerializeField] private float raycastDown = 2.1f;
    [SerializeField] private float additionalGravity = 1f;
    [SerializeField] private float runningMultiplier = 3f;

    // Private
    Vector3 walk;
    private Rigidbody rb;
    private bool isRunning;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Jump();
        walk.x = Input.GetAxisRaw("Horizontal");
        walk.z = Input.GetAxisRaw("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);

    }

    void FixedUpdate()
    {
        Move();
        AddGravity();
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
        if (isRunning) newDir *= runningMultiplier;
        rb.MovePosition(rb.position + rb.transform.TransformDirection(newDir));
    }

    void AddGravity()
    {
        rb.AddForce(-transform.up * additionalGravity * Time.fixedDeltaTime, ForceMode.Acceleration);
    }
}
