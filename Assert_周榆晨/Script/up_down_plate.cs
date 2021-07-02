using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_down_plate : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;

    public Transform top, buttom;
    public float speed;
    private bool isup;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        transform.DetachChildren();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isup)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, speed);
            if (rbody.position.y >= top.position.y)
            {
                isup = false;
            }
        }
        else
        {
            rbody.velocity = new Vector2(rbody.velocity.x, -speed);
            if (rbody.position.y <= buttom.position.y)
            {
                isup = true;
            }
        }
    }


}
