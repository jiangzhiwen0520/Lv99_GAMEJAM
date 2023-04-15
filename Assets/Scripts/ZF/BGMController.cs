using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("bgm∆¨∂Œ")]
    public AudioClip[] audioClips;
    private AudioSource m_audioSource;
    private bool m_up,m_down;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_up)
        {
            VolumeUp();
            if (m_audioSource.volume >= 1) m_up = false;
        }
        if (m_down)
        {
            VolumeDown();
            if (m_audioSource.volume <= 0) m_down = false;
        }
        
    }
    public void PlayAudio(int i)
    {
        m_audioSource.volume = 0;
        m_up = true;
        m_audioSource.clip = audioClips[i];
        m_audioSource.Play();
    }
    public void StopAudio()
    {
        m_down = true;
    }
    public void VolumeDown()
    {
        m_audioSource.volume -= Time.deltaTime * 0.5f;
    }
    public void VolumeUp()
    {
        m_audioSource.volume += Time.deltaTime * 0.5f;
        if (m_audioSource.volume == 0)
        {
            m_audioSource.Stop();
        }
    }
}
