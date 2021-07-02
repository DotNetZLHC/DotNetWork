using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAnim : MonoBehaviour
{
    public Animator triggerAnima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void readySetFalse()
    {
        triggerAnima.SetBool("ready", false);
    }

    void readySetTrue()
    {
        triggerAnima.SetBool("ready", true);
    }
}
