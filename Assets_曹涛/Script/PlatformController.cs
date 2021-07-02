using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : Crank
{
    public Transform uppoint, downpoint;
    public Rigidbody2D platform;
    public float speed;
    private float upy, downy;
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();
        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(uppoint);
        Destroy(downpoint);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPosition();

    }

    void SwitchPosition()
    {
        if (crank_down2.activeSelf == true)
        {
            if (transform.position.y < downy)
            {
                platform.velocity = new Vector2(transform.position.x, speed);

            }
        }
        else if (crank_down.activeSelf == true)
        {
            if (transform.position.y < upy)
            {
                platform.velocity = new Vector2(transform.position.x, speed);
            }
        }
    }
}
