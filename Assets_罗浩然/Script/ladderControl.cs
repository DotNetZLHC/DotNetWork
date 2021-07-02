using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderControl : MonoBehaviour
{
    public Animator ladderAnim;
    public Animator triggerAnim;
    private bool flag = true;

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (flag)
            {
                triggerAnim.SetBool("turn", true);
                ladderAnim.SetBool("move", true);
                Invoke("changeFlagFalse", 1f);
            }
            else
            {
                
                triggerAnim.SetBool("turn", false);
                ladderAnim.SetBool("move", false);
                Invoke("changeFlagTrue", 1f);
            }
        }
    }

    private void changeFlagTrue()
    {
        flag = true;
    }

    private void changeFlagFalse()
    {
        flag = false;
    }
}
