using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_top : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame


    public void SpikeDown()
    {
        rbody.gravityScale = 2;
    }

    public void onTrigerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Dead dead = GameObject.Find("deadline").GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
        }
    }
}
