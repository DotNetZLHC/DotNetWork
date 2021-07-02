using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1 );
            PlayerController.key = true;
        }
    }
}
