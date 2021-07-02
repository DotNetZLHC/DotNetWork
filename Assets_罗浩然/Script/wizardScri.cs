using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardScri : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public Animator clock;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TrapUsingClock()
    {
        clock.SetBool("clockGo", true);
        Invoke("clockFalse", 1f);
        left.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        right.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void clockFalse()
    {
        clock.SetBool("clockGo", false);
    }
}
