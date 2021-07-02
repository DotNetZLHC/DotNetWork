using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderBackArea : MonoBehaviour
{
    private bool flag = true;
    public Animator ladder1p1;
    public Animator ladder1p2;
    public Animator ladder1p3;
    public Animator ladder1p4;
    public Animator ladder1p5;
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
        if (flag)
        {
            Time.timeScale = 0.5f;
            ladder1p1.SetBool("back", true);
            flag = false;
        }
    }
}
