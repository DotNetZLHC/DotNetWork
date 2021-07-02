using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private CircleCollider2D cir;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        cir = GetComponent<CircleCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trap")
        {
            Destroy(collision.gameObject);
        }
    }
   
}
