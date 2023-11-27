using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the balloon's movement
    private Vector2 movementDirection = Vector2.right; // Initial movement direction
    private float screenHalfWidthInWorldUnits; // Half width of the screen in world units

    void Start()
    {
        // Calculate half the width of the screen in world units
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        // Move the balloon in the current direction
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        // Check if the balloon is off the screen
        if (Mathf.Abs(transform.position.x) > screenHalfWidthInWorldUnits)
        {
            // Flip the direction and move the balloon back on screen
            movementDirection = new Vector2(-movementDirection.x, movementDirection.y);
            float newX = Mathf.Sign(transform.position.x) * screenHalfWidthInWorldUnits * 0.9f; // Adjust position slightly to prevent sticking to the edge
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
