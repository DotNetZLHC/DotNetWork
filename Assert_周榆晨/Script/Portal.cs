using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private BoxCollider2D coll;

    public GameObject dialog_Tierd;
    public GameObject dialog_portal;
    public Transform Destination;
    private bool isUse;

    PlayerControl player;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && ! isUse)
        {
            player = collision.gameObject.GetComponent<PlayerControl>();
            dialog_portal.SetActive(true);
            Invoke("Trans",2f);
        }
        else if(collision.tag == "player" && isUse)
        {
            dialog_Tierd.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Invoke("SetUseFalse", 5f);
        }
        dialog_portal.SetActive(false);
        dialog_Tierd.SetActive(false);
    }

    public void Trans()
    {
        isUse = true;
        Destination.gameObject.GetComponent<Portal>().SetUseTrue();
        player.Deliver(Destination);
    }
    public void SetUseTrue()
    {
        isUse = true;
    }

    public void SetUseFalse()
    {
        isUse = false;
    }
}
