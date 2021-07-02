using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void exit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

    }
    public void pause()
    {
         Time.timeScale = 0f;
    }

    public void closePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void volumeSet(float value)
    {
        audioMixer.SetFloat("mainVolume", value);
    }
}
