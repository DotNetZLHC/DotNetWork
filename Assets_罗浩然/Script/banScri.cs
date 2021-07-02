using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banScri : MonoBehaviour
{
    private bool conFlag=true;
    public Rigidbody2D rb;
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
        if (conFlag)
        {
            clock.SetBool("clockFrozen", true);
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("changeFlag", 1f);
        }
        else
        {
            clock.SetBool("clockOn", true);
            rb.bodyType = RigidbodyType2D.Dynamic;
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
