using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject dialog;

    public void isDead()
    {
        SoundManage.SoundManager.PlayDBGM();
        dialog.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            dialog.SetActive(true);
        }
    }
    public void exit()
    {
        dialog.SetActive(false);
    }
}
