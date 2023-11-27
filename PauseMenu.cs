using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Assuming Escape key for pause
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Resume game time
        isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // Pause game time
        isGamePaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Resume time before switching scenes
        SceneManager.LoadScene("deargod"); // Replace with your main menu scene name
    }
}
