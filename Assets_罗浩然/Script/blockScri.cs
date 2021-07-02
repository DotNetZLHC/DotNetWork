using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScri : MonoBehaviour
{

    public GameObject blockDialog;
    public AudioSource faceAudio;
    public GameObject trap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            faceAudio.Play();
            blockDialog.SetActive(true);
            trap.GetComponent<Animator>().Play("trap");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            blockDialog.SetActive(false);
        }
    }
}
