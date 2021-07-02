using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mouse : Enemy
{
    private Rigidbody2D rb;
    //private Animator anim;
    private Collider2D coll;
    public bool FaceLeft = true;
    public float speed;
    // Start is called before the first frame update
    private void Update()
    {
        Movement();
    }
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            JumpOn();
        }
        if(collision.gameObject .tag == "Bush")
        {
            if (FaceLeft)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                FaceLeft = false;
            }
            else if (!FaceLeft)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(speed, rb.velocity.y);
                FaceLeft = true;
            }
        }
    }
 
    void Movement()
    {
        if (FaceLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (!FaceLeft)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}
