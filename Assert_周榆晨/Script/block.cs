using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rbody;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rbody = GetComponent<Rigidbody2D>();
    }

    public void BlockDown()
    {
        rbody.gravityScale = 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "opossum" && rbody.velocity.y<0)
        {
            opossum opo = collision.gameObject.GetComponent<opossum>();
            opo.onHead();
        }
    }
}
