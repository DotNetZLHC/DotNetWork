using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(0, player.position.y, -10f);
    }
}
