using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 5f; // Time between spawns

    void Start()
    {
        Debug.Log("Bird prefab assigned: " + (birdPrefab != null));
        InvokeRepeating("SpawnBird", spawnInterval, spawnInterval);
    }


    void SpawnBird()
    {
        // Check if birdPrefab is assigned
        if (birdPrefab != null)
        {
            float spawnYPosition = Random.Range(-5f, 5f); // Adjust range based on your game's vertical limits
            Vector3 spawnPosition = new Vector3(10, spawnYPosition, 0); // Adjust X position based on screen width

            // Check if the spawned bird is not null before instantiating
            GameObject spawnedBird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
            if (spawnedBird != null)
            {
                // Optionally, you can set up additional properties or behaviors for the spawned bird here
            }
        }
        else
        {
            Debug.LogError("Bird Prefab is not assigned in the BirdSpawner.");
        }
    }
}
