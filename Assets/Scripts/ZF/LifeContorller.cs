using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeContorller : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("最大生命值")]
    public float maxHp;
    private float m_hp;
    void Start()
    {
        m_hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_hp == 0) Debug.Log("患者死亡，手术失败");
    }
    public void LifeChange(float down)
    {
        m_hp += down;
        //m_hp = Mathf.Clamp(m_hp, 0, maxHp);
        if (m_hp <= 0) m_hp = 0;
    }
}
