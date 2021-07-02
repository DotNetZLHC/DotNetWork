using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderClock : MonoBehaviour
{
    public Animator clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clockStop()
    {
        clock.SetBool("clockOn", false);
        //Time.timeScale = 1f;
    }

    void clockOn()
    {
        clock.SetBool("clockOn", true);
    }
}
