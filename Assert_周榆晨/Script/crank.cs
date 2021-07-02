using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crank : MonoBehaviour
{
    private BoxCollider2D coll;
    private Animator animator;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("cranking", true);
        block blo = GameObject.Find("block-big").GetComponent<block>();
        blo.BlockDown();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("cranking", false);
    }
}
