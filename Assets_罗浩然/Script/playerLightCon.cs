using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLightCon : MonoBehaviour
{
    public Animator playerLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetLight()
    {
        playerLight.SetBool("onOrNot", false);
    }
}
