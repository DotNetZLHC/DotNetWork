using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opposum_gem : MonoBehaviour
{
    private Rigidbody2D rbody;
    private CircleCollider2D cir;
    public float speed;
    private Animator animator;
    private bool isMove;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        cir = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("moving", false);
        animator.SetBool("isGem", true);
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    public void SetMove()
    {
        isMove = true;
        animator.SetBool("moving", true);
    }

    void Move()
    {
        if (isMove)
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Dead dead = GameObject.Find("deadline").GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
        }
    }
    public void Death()
    {
        Destroy(gameObject);
        GameObject.Find("collections/hideCollection").SetActive(true);
    }
    public void onHead()
    {
        animator.SetBool("death", true);
        SoundManage.SoundManager.PlayBOMB();
    }
}
