using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the pin's movement
    private Vector2 movementDirection = Vector2.right; // Initial movement direction
    private float screenHalfWidthInWorldUnits; // Half width of the screen in world units

    private AudioSource audioSource; // Add this line to declare the AudioSource variable

    void Start()
    {
        // Calculate half the width of the screen in world units
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;

        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource here
    }

    void Update()
    {
        // Move the pin in the current direction
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        // Check if the pin is off the screen
        if (Mathf.Abs(transform.position.x) > screenHalfWidthInWorldUnits)
        {
            // Flip the direction and move the pin back on screen
            movementDirection = new Vector2(-movementDirection.x, movementDirection.y);
            float newX = Mathf.Sign(transform.position.x) * screenHalfWidthInWorldUnits * 0.9f; // Adjust position slightly to prevent sticking to the edge
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected with: " + other.gameObject.name);
        if (other.CompareTag("Balloon"))
        {
            Debug.Log("Balloon hit by pin");
            Debug.Log("AudioSource: " + audioSource);
            Debug.Log("AudioClip: " + audioSource.clip);
            Debug.Log("Playing collision sound"); // Debug statement
            if (audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip); // Play the sound using PlayOneShot
            }
            Destroy(other.gameObject); // Destroy the balloon
            Destroy(gameObject, audioSource.clip.length); // Optionally, destroy the pin as well
        }
        else if (other.CompareTag("Bird"))
        {
            // Logic for colliding with a bird
            HandleBirdCollision();
        }
    }

    private void HandleBirdCollision()
    {
        // Example: Deflect the pin in a different direction
        movementDirection = new Vector2(-movementDirection.x, movementDirection.y);

        // Optionally, play a sound effect or trigger a visual effect
    }
}
