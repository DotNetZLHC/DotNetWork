using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class lightCon : MonoBehaviour
{
    public GameObject eye;
    public Animator playerLight;
    public GameObject dialogPanel;
    public GameObject endPanel;
    public GameObject clock;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.S)&&flag)
        {
            clock.SetActive(true);
            flag = false;
            dialogPanel.SetActive(false);
            endPanel.SetActive(true);
            collision.SendMessage("clockOn");
            eye.SetActive(true);
            playerLight.SetBool("onOrNot", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&flag)
        {
            dialogPanel.SetActive(true);
        }
        if (collision.tag=="Player"&&!flag)
        {
            endPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&flag)
        {
            dialogPanel.SetActive(false);
        }
        else if (collision.tag == "Player" && !flag)
        {
            endPanel.SetActive(false);
        }
    }
}
