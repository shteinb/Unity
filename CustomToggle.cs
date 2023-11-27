using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    public Toggle toggle;
    public Image toggleImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public AudioSource musicAudioSource; // Reference to the AudioSource for music

    void Start()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
            OnToggleChanged(toggle.isOn);
        }
        else
        {
            Debug.LogWarning("Toggle is not assigned in the Inspector");
        }
    }

    void OnToggleChanged(bool isOn)
    {
        if (toggleImage != null)
        {
            toggleImage.sprite = isOn ? musicOnSprite : musicOffSprite;
        }
        else
        {
            Debug.LogWarning("Toggle Image is not assigned in the Inspector");
        }

        // Play or stop the music based on the Toggle's state
        if (musicAudioSource != null)
        {
            if (isOn)
            {
                musicAudioSource.Play();
            }
            else
            {
                musicAudioSource.Stop();
            }
        }
        else
        {
            Debug.LogWarning("Music AudioSource is not assigned in the Inspector");
        }
    }
}
