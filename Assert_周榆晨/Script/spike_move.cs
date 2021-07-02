using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_move : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    public Transform place;
    public Transform boundary;
    public float speed;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        transform.DetachChildren();
    }

    void Update()
    {
        Invoke("Move",5f);
    }

    void Back()
    {
        rbody.position = new Vector2(place.position.x, place.position.y);
    }
    void Move()
    {
        if (rbody.position.x >= boundary.position.x)
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(0, 0);
            Back();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
