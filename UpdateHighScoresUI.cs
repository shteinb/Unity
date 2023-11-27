using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHighScoresUI : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreTexts; // Array to hold your TMP elements

    void Start()
    {
        UpdateHighScoreDisplay();
    }

    void UpdateHighScoreDisplay()
    {
        int[] highScores = HighScoresManager.GetHighScores();

        for (int i = 0; i < highScores.Length; i++)
        {
            if (highScoreTexts.Length > i) // Notice that it's not 'i + 1' here
            {
                highScoreTexts[i].text = (i + 1).ToString() + ". " + highScores[i].ToString();
            }
        }
    }

}
