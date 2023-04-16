using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("“Ù∆µ◊ ‘¥∆¨∂Œ")]
    public AudioClip[] audioClips;
    private AudioSource m_audioSource;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(int i)
    {
        m_audioSource.PlayOneShot(audioClips[i]);
    }
    public void PlayAudio(int i,float a)
    {
        m_audioSource.PlayOneShot(audioClips[i],a);
    }

    internal void Stop()
    {
        throw new NotImplementedException();
    }
}
