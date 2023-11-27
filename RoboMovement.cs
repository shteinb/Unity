using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    public GameObject pinPrefab; // The pin prefab to be shot
    public float moveSpeed = 5f; // Speed at which the player moves
    public float jumpForce = 10f; // Force of the player's jump
    private Rigidbody2D rb; // Rigidbody2D component of the player
    private bool isFacingRight = true; // Check which direction the player is facing

    void Start()
    {
        // Get the Rigidbody2D component from the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on movement direction
        if ((isFacingRight && moveInput < 0) || (!isFacingRight && moveInput > 0))
        {
            FlipSprite();
        }

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Check if the game is not paused before shooting
        if (Input.GetButtonDown("Fire1") && !PauseMenu.isGamePaused)
        {
            ShootPin();
        }
    }

    void FlipSprite()
    {
        // Change the direction the player is facing
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void ShootPin()
    {
        // Instantiate the pin at the player's current position
        Instantiate(pinPrefab, transform.position, Quaternion.identity);

        // Note: The pin's movement is controlled by the PinMovement script attached to the pinPrefab
    }
}
