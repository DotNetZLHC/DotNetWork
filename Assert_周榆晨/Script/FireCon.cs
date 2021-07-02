using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCon : MonoBehaviour
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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "trap")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "skull")
        {
            collision.gameObject.GetComponent<Skull>().Fired();
 
        }
    }
}
