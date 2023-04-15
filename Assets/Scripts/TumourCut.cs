using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumourCut : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("��������Ҫ�г���Ѫ������")]
    public int numOfVessel;
    private float m_destoryTime=1f;
    IEnumerator Shack()
    {
        Debug.Log("��");
        var oirPos = transform.position;
        for (float i = 0; i < 0.5f; i += 0.1f)
        {
            transform.position = oirPos + Random.Range(-0.1f, 0.1f) * Vector3.right + Random.Range(-0.1f, 0.1f) * Vector3.up;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.transform.position = oirPos;
        yield return null;
    }
    void Start()
    {
        //StartCoroutine("Shack");
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfVessel == 0) {
            //StartCoroutine("Shack");
            MyDestory();
            Debug.Log("�����ɹ�");
        }
    }
    public void Cut()
    {
        --numOfVessel;
        //IEnumerator enumerator = (IEnumerator)Shack();
        if (numOfVessel == 0) {
            //Debug.Log("��ʼ��");
            StartCoroutine(Shack()); 
        }
    }
    public void MyDestory()
    {
        m_destoryTime -= Time.deltaTime;
        if (m_destoryTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, m_destoryTime);
        }
    }

}
