using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapline : MonoBehaviour
{
    private BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Spike_top spike;
        spike = GameObject.Find("Environment/spikes-top").GetComponent<Spike_top>();
        spike.SpikeDown();
        spike = GameObject.Find("Environment/spikes-top_1").GetComponent<Spike_top>();
        spike.SpikeDown();
        spike = GameObject.Find("Environment/spikes-top_2").GetComponent<Spike_top>();
        spike.SpikeDown();
    }
}
