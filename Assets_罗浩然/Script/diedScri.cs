using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diedScri : MonoBehaviour
{
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void waitToReset()
    {
        Invoke("resetScene", 2);
    }
}
