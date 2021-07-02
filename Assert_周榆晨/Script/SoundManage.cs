using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static SoundManage SoundManager;
    
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip BGM, DBGM, BOMB;

    public void Awake()
    {
        SoundManager = this;
    }
    public void PlayBGM()
    {
        audioSource.clip = BGM;
        audioSource.Play();
    }

    public void PlayDBGM()
    {
        audioSource.clip = DBGM;
        audioSource.Play();
    }

    public void PlayBOMB()
    {
        audioSource.clip = BOMB;
        audioSource.Play();
    }
}
