using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] ac;
    private bool change;
    void Start()
    {
        change = true;
    }

    // Update is called once per frame
    void Update()
    {
        float l = GetComponent<LifeContorller>().GetLife();
        if (l >= 120)
        {
            if (GetComponent<AudioSource>().clip != ac[0])
            {
                GetComponent<AudioSource>().clip = ac[0];
                GetComponent<AudioSource>().Play();
            }
        }
        else if (l >= 60)
        {
            if (GetComponent<AudioSource>().clip != ac[1])
            {
                GetComponent<AudioSource>().clip = ac[1];
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (GetComponent<AudioSource>().clip != ac[2])
            {
                GetComponent<AudioSource>().clip = ac[2];
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
