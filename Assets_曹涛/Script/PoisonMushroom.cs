using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    public Collider2D coll;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.JumpOn();
        }
     
    }
}
