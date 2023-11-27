using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BalloonPop : MonoBehaviour
{
    public static int score = 0; // Static variable to keep track of the score
    public TextMeshProUGUI scoreText; // Reference to the Text component to display the score
    public int levelNumber; 
    public TextMeshProUGUI levelText;

    void Start()
    {
        UpdateScoreUI();
        UpdateLevelUI();  // Update the level UI in start
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + levelNumber;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pin"))
        {
            // Calculate score based on balloon size (smaller balloons give more points)
            int points = Mathf.FloorToInt((1000 / transform.localScale.x) * 0.01f);
            score += points;
            UpdateScoreUI(); // Update the score UI whenever the score changes
            Debug.Log("Score: " + score); // Log the score for debugging

            Destroy(gameObject); // Destroy the balloon
            HandleLevelCompletion(); // Handle the level completion
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the text to show the current score
        }
    }

    void HandleLevelCompletion()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Decide which scene to load next or end the game
        if (currentScene.name == "Level3")
        {
            // Save the high score
            HighScoresManager.SaveScore(score);

            // Reset the score for the next game
            score = 0;

            // Load the main menu or an end-game scene
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
