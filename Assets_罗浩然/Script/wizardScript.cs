using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardScript : MonoBehaviour
{
    public Transform player;
    public GameObject fireball;
    public Animator wizard;
    public Collider2D wizardCol;
    public bool fireballFlag=true;
    public GameObject outDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&fireballFlag)
            wizard.SetBool("attack", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&fireballFlag) {
            wizard.SetBool("attack", true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wizard.SetBool("attack", false);
        }
    }

    private void setFireBall() {
        if (fireballFlag)
        {
            fireball.SendMessage("setFireReady");
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2((player.position.x - fireball.transform.position.x), (player.position.y - fireball.transform.position.y));
            //fireba.velocity = new Vector2(player.position.x, player.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trapBlock")
        {
            wizard.SetBool("die", true);

            wizardCol.enabled = false;
        }
    }

    public void fireDisPlay()
    {
        fireballFlag = true;
    }

    private void setFireBool()
    {
        fireballFlag = false;
        wizard.SetBool("attack", false);
    }

    private void death()
    {
        Destroy(gameObject);
    }

    private void outDoorOpen()
    {
        outDoor.SendMessage("outDoorOpen");
    }
}
