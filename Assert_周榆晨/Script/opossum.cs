using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : MonoBehaviour
{
    private Rigidbody2D rbody;

    public Transform left, right;
    public float speed;
    private float leftx, rightx;
    private bool isleft;
    private Animator animator;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.DetachChildren();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
        isleft = true;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isleft)
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
            if (rbody.position.x <= leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isleft = false;
            }
        }
        else
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
            if (rbody.position.x>= rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isleft = true;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Dead dead = GameObject.Find("deadline").GetComponent<Dead>();
            dead.isDead();
            this.GetComponent<AudioSource>().enabled = false;
            collision.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void Death()
    {
        Destroy(this.gameObject);
        GameObject.Find("collections/hideCollection").SetActive(true);
    }
    public void onHead()
    {
        animator.SetBool("death", true);
        SoundManage.SoundManager.PlayBOMB();
    }
}
