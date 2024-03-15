using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerScale ps;

    public Rigidbody rb;

    public float moveSpeed;
    public float movementMultiplier;

    public float rotationSpeed;
    public float rotationMultiplier;

    private Vector3 movementDirection;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        UpdateSpeed();

        UpdateHeight();

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        rb.MovePosition(rb.position + movementDirection * (moveSpeed * movementMultiplier) * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movementDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, (rotationSpeed * rotationMultiplier) * Time.deltaTime);
        }
    }

    public void UpdateSpeed()
    {
        moveSpeed = (-Mathf.Sqrt(ps.scale) + 10);
        rotationSpeed = (-Mathf.Sqrt(ps.scale) + 10);
    }

    public void UpdateHeight()
    {
        float yPos = (ps.scale / 2f) + 0.1f;
        rb.position = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }
}