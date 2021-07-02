using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Trap : MonoBehaviour
{
    private BoxCollider2D coll;
    public GameObject trap_former;
    public GameObject trap_latter;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        trap_former.SetActive(false);
        trap_latter.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        trap_former.SetActive(true);
        trap_latter.SetActive(false);
    }

}
