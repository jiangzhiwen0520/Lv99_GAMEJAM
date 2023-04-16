using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoomDi : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_time;
    void Start()
    {
        m_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        float t = 3;
        if (Convert.ToInt32((GetComponent<TextMeshProUGUI>().text)) > 20)
        {
            t = 3;
        }
        else if (Convert.ToInt32((GetComponent<TextMeshProUGUI>().text)) > 10) t = 2;
        else if (Convert.ToInt32((GetComponent<TextMeshProUGUI>().text)) > 5)
        {
            t = 1;
        }
        else
        {
            t = 0.3f;
        }
        if (m_time> t){
            GetComponent<AudioSource>().Play();
            m_time = 0;
        }
    }
}
