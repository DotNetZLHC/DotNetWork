using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);

    }

    public void closePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void exit()
    {
        Application.Quit();
    }
}
