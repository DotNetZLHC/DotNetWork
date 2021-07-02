using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBlockScript : MonoBehaviour
{
    public Animator blockAnim;
    public Animator clock;
    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!flag)
        {
            blockAnim.SetBool("trapDown", true);
            flag = true;
        }
    }

    void setBack()
    {
        blockAnim.SetBool("trapDown", false);
        flag = false;
    }

    void clockStop()
    {
        clock.SetBool("clockOn",false);
        Time.timeScale = 1f;
    }

    void clockOn()
    {
        clock.SetBool("clockOn", true);
    }
}
