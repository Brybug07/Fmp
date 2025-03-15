using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Speed of movement
    private Rigidbody2D rb;           // Reference to the Rigidbody2D component
    private Vector2 movement;         // Stores normalized movement direction
    private Animator animator;

    private float xInput;             // Store horizontal input
    private float yInput;             // Store vertical input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get raw input values
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        // Create normalized movement vector
        movement = new Vector2(xInput, yInput).normalized;

        // Update Animator parameters
        if (movement != Vector2.zero)
        {
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        }
    }

    void FixedUpdate()
    {
        // Move the player using physics
        rb.linearVelocity = movement * moveSpeed;
    }
}
