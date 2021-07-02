using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LockedDoor : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)&& PlayerController.key == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
