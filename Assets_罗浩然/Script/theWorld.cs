using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theWorld : MonoBehaviour
{
    public Animator theW;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void resetBool()
    {
        theW.SetBool("set", false);
    }
}
