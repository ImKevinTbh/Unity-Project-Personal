using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 15f;
    public float JumpPower = 1;
    Rigidbody2D rb;
    BoxCollider2D box;
    public LayerMask mask;
    public int maxJumps = 2;
    private int jumps = 0;
    private bool onground = false;
    // Start is called before the first frame update
    void Start()
    {
        jumps = maxJumps;
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps; // Reset Jumps Back To Max
            onground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onground = false;
        }
    }


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement;
        movement = new Vector3(inputX * speed, 0f, 0f);
        movement *= Time.deltaTime * 100;
        movement = Vector3.ClampMagnitude(movement, speed); // Stop Going Too Fast
        rb.AddForce(movement, ForceMode2D.Force);

        if (inputX < 1 && inputX > -1 && onground) // On Ground Drag
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.99f, rb.velocity.y, 0f); // Slowly Reduce Velocity on the X axis while keeping Y axis the same
        }
        else if (inputX < 1 && inputX > -1 && !onground) // Midair Drag
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.9975f, rb.velocity.y, 0f); // Slowly Reduce Velocity on the X axis while keeping Y axis the same (More precise, even slower)
        }
        Debug.Log(inputX);

        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            jumps--;
            rb.AddForce((Vector3.up * JumpPower)*rb.mass, ForceMode2D.Impulse);
        }

    }
}
