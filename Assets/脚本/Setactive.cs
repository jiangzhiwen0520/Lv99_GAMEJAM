using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setactive : MonoBehaviour
{
    [SerializeField] private GameObject trigger;

    private float triggerTime = 60f;
    private float pressTime = 2f;
    private float timePressed = 0;
    private float time = 0;
    private bool istrigger = false;

    void Start()
    {
        // 确保在开始时将触发器设置为非激活状态
        trigger.SetActive(false);
    }

    void Update()
    {
        timePressed += Time.deltaTime;
        if (timePressed >= pressTime)
        {
            trigger.SetActive(false);
        }

        if (istrigger)
        {
            // 设置触发器为激活状态
            trigger.SetActive(true);
        }
    }

    private void TimeAdd()
    {
        time += Time.deltaTime;
        if (time >= triggerTime)
        {
            istrigger = true;
            time = 0;
        }
    }
}
