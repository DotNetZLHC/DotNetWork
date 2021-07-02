using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowUI()
    {
        GameObject.Find("Canvas/menu/UI").SetActive(true);
    }
    public void ShowStart()
    {
        GameObject.Find("Canvas/menu/UI").SetActive(false);
        GameObject.Find("Canvas/menu/start").SetActive(true);
    }
    
}
