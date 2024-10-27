using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; // Add jump force as a separate variable
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when facing left/right with scale set to 1.5
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // Facing right
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f); // Facing left

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}