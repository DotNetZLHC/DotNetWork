using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankDialog : MonoBehaviour
{
    public GameObject crankDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crankDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            crankDialog.SetActive(false);
        }


    }
}
