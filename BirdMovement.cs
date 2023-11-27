using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        // Move the bird to the left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Optionally, destroy the bird if it goes off screen
        if (transform.position.x < -10) // Adjust value based on your screen width
        {
            Destroy(gameObject);
        }
    }
}
