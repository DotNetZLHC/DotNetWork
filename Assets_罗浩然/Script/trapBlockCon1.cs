using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBlockCon1 : MonoBehaviour
{
    public Animator trapBlock1;
    public Animator trapBlock2;
    public Animator trapBlock3;
    public Animator trapBlock4;
    public Animator chain1;
    private bool flag = true;
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
            chain1.SetBool("trapClock", true);
            trapBlock1.SetBool("trapClock", true);
            trapBlock2.SetBool("trapClock", true);
            trapBlock3.SetBool("trapClock", true);
            trapBlock4.SetBool("trapClock", true);
            flag = false;
        }
    }
}
