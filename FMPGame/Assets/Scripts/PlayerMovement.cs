using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;      // Reference to the Rigidbody2D component
    private Vector2 movement;    // Stores player input for movement

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player's input for movement (horizontal and vertical)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to ensure consistent movement speed
        movement = new Vector2(moveX, moveY).normalized;
    }

    // FixedUpdate is called at a fixed time interval, used for physics-based movement
    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D component
        rb.linearVelocity = movement * moveSpeed;
    }
}
