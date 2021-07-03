using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroFly : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameManager gameManager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.ifStart) return;
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, 5);
        }
    }

    public void ChangeState(bool isFly)
    {
        if (isFly)
        {
            rb.simulated = true;
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 1);
            rb.simulated = false;
        }

    }
}
