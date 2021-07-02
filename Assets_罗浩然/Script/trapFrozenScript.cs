using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapFrozenScript : MonoBehaviour
{
    public bool conFlag = true;
    public Rigidbody2D spikeBall1;
    public Rigidbody2D spikeBall2;
    public Rigidbody2D spikeBall3;
    public Rigidbody2D spikeBall4;
    public Rigidbody2D spikeBall5;
    public Animator theWorld;
    public AudioSource stop;
    public Animator clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TrapUsingClock()
    {
        if (conFlag) {
            clock.SetBool("clockFrozen", true);
            theWorld.SetBool("set", true);
            stop.Play();
            spikeBall1.bodyType = RigidbodyType2D.Static;
            spikeBall2.bodyType = RigidbodyType2D.Static;
            spikeBall3.bodyType = RigidbodyType2D.Static;
            spikeBall4.bodyType = RigidbodyType2D.Static;
            spikeBall5.bodyType = RigidbodyType2D.Static;
            Invoke("changeFlag", 2f);
        }
        else
        {
            clock.SetBool("clockOn", true);
            spikeBall1.bodyType = RigidbodyType2D.Dynamic;
            spikeBall2.bodyType = RigidbodyType2D.Dynamic;
            spikeBall3.bodyType = RigidbodyType2D.Dynamic;
            spikeBall4.bodyType = RigidbodyType2D.Dynamic;
            spikeBall5.bodyType = RigidbodyType2D.Dynamic;
            Invoke("changeFlag1", 1f);
        }

    }

    private void changeFlag()
    {
        conFlag = false;
        clock.SetBool("clockFrozen", false);
    }

    private void changeFlag1()
    {
        conFlag = true;
        clock.SetBool("clockOn", false);
    }
}
