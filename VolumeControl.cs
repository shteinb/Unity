using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource; // Reference to your audio source

    void Start()
    {
        // Initialize the slider's value to the current volume
        volumeSlider.value = AudioListener.volume;

        // Optionally, you can start playing a sound here if you want immediate feedback
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void SetVolume()
    {
        // Adjust the game's volume based on the slider's value
        AudioListener.volume = volumeSlider.value;
        // Also adjust the volume of the AudioSource directly if needed
        if (audioSource != null)
        {
            audioSource.volume = volumeSlider.value;
        }
    }
}
