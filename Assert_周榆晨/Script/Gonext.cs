using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonext : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private CircleCollider2D cir;
    public GameObject dialog;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        cir = GetComponent<CircleCollider2D>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            dialog.SetActive(true);
            Invoke("GoNext", 2f);
        }
    }

    void GoNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
