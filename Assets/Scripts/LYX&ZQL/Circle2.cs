using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class Circle2 : MonoBehaviour
{
    [SerializeField] private GameObject circle;
    [SerializeField] private UnityEngine.Camera mainCamera;
    [SerializeField] private Transform postransform;
    [Header("游戏结束界面")]
    public GameObject gameOver;
    [Header("游戏成功界面")]
    public GameObject gameClear;
    private CinemachineBrain cinemachineBrain;
    private bool isstart = false,timeDown=false,pause=false;
    private float m_time = 0;
    private int m_realtime = 30;
    void Start()
    {
        Cursor.visible = false;
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
        circle.transform.position = postransform.position;
        Cursor.visible = true;
        isstart = false; timeDown = false; pause = false;
        m_realtime = 30;
        m_time = 0;
    }

    void Update()
    {
        //Cursor.visible = false;
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))&&!pause)
        {
            isstart = !isstart;
            timeDown = true;

        }

        if (isstart)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = 10f;

            // 从 CinemachineBrain 获取当前渲染的相机
            UnityEngine.Camera currentCamera = cinemachineBrain.OutputCamera;
            Vector3 mouseWorldPosition = currentCamera.ScreenToWorldPoint(mouseScreenPosition);

            circle.transform.position = mouseWorldPosition;

            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        if (timeDown)
        {
            TimeStart();
        }
        if (GetTime() <= 0)
        {
            Cursor.visible = true;
            isstart = false;
            pause = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            print("你已经死了");
        }
    }*/
    private void TimeStart()
    {
        m_time += Time.deltaTime;
        if (m_time >= 1)
        {
            m_time = 0;
            m_realtime--;
            if (m_realtime <= 0)
            {
                m_realtime = 0;
                isstart=false;
            }
            GameObject.Find("Timer").GetComponent<TextMeshProUGUI>().text = Convert.ToString(m_realtime);
        }
    }
    public int GetTime()
    {
        return m_realtime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("BallEnd"))
        {
            Debug.Log("碰撞");
            Cursor.visible = true;
            isstart = false;
            pause = true;
            Time.timeScale = 0;
            gameClear.SetActive(true);
        }
        else if (other.gameObject.tag.Equals("Border"))
        {
            Cursor.visible = true;
            isstart = false;
            pause = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
