using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonGrowth : MonoBehaviour
{
    public float growthRate = 0.1f; // The rate at which the balloon grows
    public float growthInterval = 1f; // The time interval (in seconds) between each growth
    public float maxGrowthSize = 0.5f; // Maximum size before the balloon pops

    void Start()
    {
        // Start invoking the Grow function repeatedly at a set interval
        InvokeRepeating("Grow", growthInterval, growthInterval);
    }

    void Grow()
    {
        // Check if the balloon's size is less than the maximum size
        if (transform.localScale.x < maxGrowthSize)
        {
            // Increase the balloon's scale
            transform.localScale += new Vector3(growthRate, growthRate, growthRate);
            Debug.Log("Balloon Scale: " + transform.localScale.x); // Debugging scale
        }
        else
        {
            // Balloon has grown too big and will pop
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        Destroy(gameObject); // Destroy the balloon
        HandleLevelCompletion(); // Handle the level completion
    }

    public void HandleLevelCompletion()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level3")
        {
            HighScoresManager.SaveScore(BalloonPop.score);
            SceneManager.LoadScene("deargod"); // Replace with your main menu scene name
        }
        else if (currentScene.name == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentScene.name == "SampleScene")
        {
            SceneManager.LoadScene("Level2");
        }
    }

}
