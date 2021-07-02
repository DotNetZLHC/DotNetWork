using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outDoor : MonoBehaviour
{
    public GameObject endPanel;
    public Animator outdoor;
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
        if (collision.tag == "Player")
        {
            endPanel.SetActive(true);
        }
    }

    public void outDoorOpen()
    {
        outdoor.SetBool("open", true);
    }
}
