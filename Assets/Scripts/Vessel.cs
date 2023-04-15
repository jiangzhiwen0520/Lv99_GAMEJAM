using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("联通的肿瘤物体")]
    public GameObject tumor;
    private bool m_hasCut;
    void Start()
    {
        m_hasCut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cut()
    {
        if (!m_hasCut)
        {
            m_hasCut = true;
            tumor.GetComponent<TumourCut>().Cut();
        }
    }
}
