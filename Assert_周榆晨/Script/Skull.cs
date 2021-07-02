using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rbody;
    private Animator animator;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fire")
        {
            Invoke("Fired", 2f);
        }    
    }

    public void Dead()
    {
        GameObject.Find("Environment/door_next").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Destroy(GameObject.Find("Environment/spikes").gameObject);
        Destroy(this.gameObject);
    }

    public void Fired()
    {
        animator.SetTrigger("death");
        SoundManage.SoundManager.PlayBOMB();
    }
}
