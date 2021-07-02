using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private BoxCollider2D coll;

    public void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        while (true)
        {
            Invoke("ShowTrap", 2f);
            Invoke("HideTrap", 4f);
        }
    }

    void ShowTrap()
    {
        this.gameObject.SetActive(true);
    }
    void HideTrap()
    {
        this.gameObject.SetActive(false);
    }
}
