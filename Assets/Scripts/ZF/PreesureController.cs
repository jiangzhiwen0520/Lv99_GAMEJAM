using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreesureController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textObject;
    [Header("呼吸的下降幅度")]
    public float descender;
    [Header("时间的上升幅度")]
    public float increase;
    [Header("压力最大值")]
    public float maxPressure;
    private TextMeshProUGUI m_textMesh;
    private float m_downtime;
    private float m_uptime;
    private float m_pressure = 0;
    private float m_cdtime = 0;
    private bool m_cd;
    private bool m_breath;
    private bool m_downcd;

    public bool isAP;
    void Start()
    {
        if(textObject !=null)
            m_textMesh = textObject.GetComponent<TextMeshProUGUI>();
        m_downtime = 0;
        m_uptime = 0;
        m_cdtime = 0;
        m_cd = false;
        m_breath = false;
        m_downcd = false;
    }
    private void FixedUpdate()
    {
        if(m_textMesh != null)
            m_textMesh.text = "Pressure Points: " + m_pressure;
    }
    // Update is called once per frame
    void Update()
    {
        Controller();
    }
    void Controller()
    {
        if ((Input.GetKey(KeyCode.Space) || m_breath) && !m_cd&&!isAP)
        {
            
            float pretime = m_downtime >= 1 ? m_downtime : 1;
            m_downtime += Time.deltaTime;
            if (m_downtime >= 1)//开始呼吸
            {
                m_breath = true;
                if (m_downtime >= 2) m_downtime = 2;
                Award(descender * (m_downtime - pretime));//50点压力在1s时间里下降
                //m_downtime = 0;
            }
            if (m_downtime >= 2)//进入cd 5s
            {
                m_pressure = (int)(m_pressure + 0.5f);
                m_cd = true;
                m_breath = false;
                m_downtime = 0;
            }
        }
        else
        {
            m_downtime = 0;
            float pretime = m_uptime;
            m_uptime += Time.deltaTime;
            Punishment(increase*(m_uptime- pretime));
            if (m_uptime >= 10000)
            {
                m_uptime = 0;
            }

            if (m_cd && (!Input.GetKey(KeyCode.Space) || m_downcd))//必须松开空格才能开始刷新cd，防止一直按着空格
            {
                m_downcd = true;
                m_cdtime += Time.deltaTime;
                if (m_cdtime >= 5)
                {
                    m_cdtime = 0;
                    m_cd = false;
                    m_downcd = false;
                }
            }
        }

    }
    public void Award(float point)
    {
        m_pressure -= point;
        m_pressure = Mathf.Clamp(m_pressure, 0, maxPressure);
    }
    public void Punishment(float point)
    {
        m_pressure += point;
        m_pressure = Mathf.Clamp(m_pressure, 0, maxPressure);
    }
    public float GetPressurePoint()
    {
        return m_pressure;
    }
}
