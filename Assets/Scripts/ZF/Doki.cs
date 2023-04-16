using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doki : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ac;
    private AudioSource m_as;
    private float m_time, m_l;
    void Start()
    {
        m_as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PreesureController>().enabled)
        {
            m_as.volume = 1;
            float n = GetComponent<PreesureController>().GetPressurePoint();

            m_as.pitch = 100 - n == 0 ? -2 : -1 - 0.01f * n;
        }
        else
        {
            m_as.volume = 0;
        }

    }
}
