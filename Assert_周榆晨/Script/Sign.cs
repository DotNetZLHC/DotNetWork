using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private BoxCollider2D coll;
    public GameObject dialog;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            dialog.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            dialog.SetActive(false);
        }
    }
}
