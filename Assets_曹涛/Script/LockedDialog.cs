using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDialog : MonoBehaviour
{
    public GameObject lockedDialog,unlockedDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& PlayerController.key == false)
        {
            lockedDialog.SetActive(true);
        }
        if(collision.tag == "Player"&& PlayerController.key == true)
        {
            unlockedDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lockedDialog.SetActive(false);
            unlockedDialog.SetActive(false);
        }


    }
}