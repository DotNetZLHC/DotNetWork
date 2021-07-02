using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderScript : MonoBehaviour
{
    public Animator ladderAnim;
    public float climSpeed;
    private bool flag = false;
    private bool brokenFlag=false;
    public Collider2D box;
    public Animator ladder1p1;
    public Animator ladder1p2;
    public Animator ladder1p3;
    public Animator ladder1p4;
    public Animator ladder1p5;
    public Collider2D cap1;


    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player"&&(Input.GetKey(KeyCode.W)||flag))
        {
            flag = true;
            if (Input.GetKey(KeyCode.W))
            {
                col.SendMessage("onLadder", true);
                col.GetComponent<Rigidbody2D>().gravityScale = 0;
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                col.SendMessage("onLadder", true);
                col.GetComponent<Rigidbody2D>().gravityScale = 0;
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climSpeed);
            }
            else
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage("onLadder", false);
            col.GetComponent<Rigidbody2D>().gravityScale = 1;
            flag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&!brokenFlag)
        {
            cap1.enabled = false;
            ladder1p1.SetBool("broken", true);
            ladder1p2.SetBool("broken", true);
            ladder1p3.SetBool("broken", true);
            ladder1p4.SetBool("broken", true);
            ladder1p5.SetBool("broken", true);
            box.enabled = false;
            brokenFlag = true;
        }
    }

    public void resetCol()
    {
        Time.timeScale = 1f;
        box.enabled = true;
    }

    void readySetFalse()
    {
        ladderAnim.SetBool("ready", false);
    }

    void readySetTrue()
    {
        ladderAnim.SetBool("ready", true);
    }
}
