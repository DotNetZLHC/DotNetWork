using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Crank : MonoBehaviour
{
    public GameObject crank_down,crank_up;
    public GameObject crank_down2, crank_up2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            crank_up.SetActive(false);
            crank_down.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            crank_up2.SetActive(false);
            crank_down2.SetActive(true);
        }
        
    }
}
