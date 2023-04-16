using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource m_audioSource;
    private int m_i = 0;
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
        m_i = i;
    }

    public void PlayAudio(int i, float a)
    {
        m_audioSource.PlayOneShot(audioClips[i], a);
        m_i = i;
    }

    public int GetIdx()
    {
        return m_i;
    }
}
