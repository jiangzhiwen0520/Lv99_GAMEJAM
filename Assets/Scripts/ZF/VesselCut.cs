using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselCut : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("生命值脚本所在的物体")]
    public GameObject life;
    [Header("切掉后会改变的生命值数值，负数表示减少生命值，正数表示增加生命值")]
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
