using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCut : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("����ֵ�ű����ڵ�����")]
    public GameObject life;
    [Header("�е����ı������ֵ��ֵ��������ʾ��������ֵ��������ʾ��������ֵ")]
    public float hpPoint;
    private LifeContorller m_lc;
    void Start()
    {
        m_lc = life.GetComponent<LifeContorller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        m_lc.LifeChange(hpPoint);
        Vessel v = transform.parent.gameObject.GetComponent<Vessel>();
        if (v!=null) v.Cut();
        Destroy(gameObject);
    }
}
