using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractGem : MonoBehaviour
{
    private BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Destroy(this.gameObject);
            opposum_gem opo = GameObject.Find("npc/opossum_gem").GetComponent<opposum_gem>();
            opo.SetMove();
        }
    }
}
