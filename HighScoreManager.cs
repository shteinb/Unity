using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoresManager
{
    const int MaxScores = 5;
    const string ScoreKey = "HighScore_";

    public static void SaveScore(int score)
    {
        int[] highScores = GetHighScores();

        // Add the new score at the end and sort
        highScores[MaxScores - 1] = score;
        System.Array.Sort(highScores);
        System.Array.Reverse(highScores);

        // Save the updated scores
        for (int i = 0; i < MaxScores; i++)
        {
            PlayerPrefs.SetInt(ScoreKey + i, highScores[i]);
        }
    }

    public static int[] GetHighScores()
    {
        int[] highScores = new int[MaxScores];
        for (int i = 0; i < MaxScores; i++)
        {
            highScores[i] = PlayerPrefs.GetInt(ScoreKey + i, 0);
        }
        return highScores;
    }

    // Method to clear all high scores (optional)
    public static void ClearHighScores()
    {
        for (int i = 0; i < MaxScores; i++)
        {
            PlayerPrefs.DeleteKey(ScoreKey + i);
        }
    }
}
