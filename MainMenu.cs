using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenInstructions()
    {
        // Code to display instructions or load an instructions scene
        SceneManager.LoadScene("InstructionsScene");
    }

    public void OpenSettings()
    {
        // Code to open a settings panel or load a settings scene
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("deargod"); // Replace with the actual main menu scene name
    }

}
