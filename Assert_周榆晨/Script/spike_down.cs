using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_down : MonoBehaviour
{
    private BoxCollider2D coll;
    private bool isShow;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        ShowSpike();
    }

    void ShowSpike()
    {
        isShow = true;
        this.gameObject.SetActive(true);
        Invoke("HideSpike", 2f);
    }

    void HideSpike()
    {
        isShow = false;
        this.gameObject.SetActive(false);
        Invoke("ShowSpike", 2f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Dead dead = GameObject.Find("deadline").GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
        }
    }
}
