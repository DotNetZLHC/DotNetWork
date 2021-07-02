using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer mixer;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void setVolume(float value)
    {
        mixer.SetFloat("MainVolume", value);
    }
}
