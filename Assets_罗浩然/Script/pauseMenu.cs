using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public void pauseEvent()
    {
        Time.timeScale = 0f;
    }
}
