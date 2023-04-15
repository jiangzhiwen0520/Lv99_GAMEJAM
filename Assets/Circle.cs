using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject end;
    protected bool isStart = false;
    private void Awake()
    {
        end.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f);
            if (col.Length > 0)
            {
                foreach (Collider2D i in col)
                {
                    if (i.gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        isStart = true;
                    }
                }
            }
        }

        if (isStart)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 99);
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        end.SetActive(true);
        Time.timeScale = 0;
        isStart = false;
    }
}
