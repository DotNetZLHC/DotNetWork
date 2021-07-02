using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallScri : MonoBehaviour
{
    public GameObject wizard;
    public Transform fireBallTran;
    public Animator fireBall;
    public Rigidbody2D fireballrb;
    private Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        start = fireBallTran.position;
    }

    // Update is called once per frame
    void Update()
    {
        setActiveOrNot();
    }

    private void setBool()
    {
        fireBall.SetBool("ready", false);
        fireBall.SetBool("fireballFly", true);
    }
    private void setActiveOrNot()
    {
        if (fireBallTran.position.x < 38 || fireBallTran.position.y>58||fireBallTran.position.y<40)
        {
            fireballrb.bodyType = RigidbodyType2D.Static;
            fireBall.SetBool("fireballFly", false);
            fireBall.SetBool("reset", true);
            fireBallTran.position = start;
            //fireBall.Play("fireballReset");
            fireballrb.bodyType = RigidbodyType2D.Dynamic;
            wizard.SendMessage("fireDisPlay");
        }
    }

    public void setFireReady()
    {
        fireBall.SetBool("reset", false);
        fireBall.SetBool("ready", true);
    }
}
