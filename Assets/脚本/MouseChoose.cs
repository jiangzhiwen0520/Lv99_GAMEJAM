using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChoose : MonoBehaviour
{
    [SerializeField] private GameObject msk;
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject Arow;
    private float threshold = 0.1f;
    private Vector3 scale;
    private Color color;

    private bool isPressed = false;
    public bool shoot=false;
    
    private float step = 0.025f;
    private float pressTime = 2f; // 阀值，2秒钟
    private float scaleY;
    private float starty;
    private float timePressed = 0.0f; // 鼠标按下的时间

    void Start()
    {
        scale = msk.GetComponent<Transform>().localScale;
        color = mouse.GetComponent<SpriteRenderer>().color;
        scaleY = Arow.transform.localScale.y;
        starty = Arow.transform.localScale.y;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            
            timePressed = 0.0f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            
            timePressed = 0.0f;
        }

        if (isPressed)
        {
            timePressed += Time.deltaTime; // 记录按下的时间
            scaleY -= 0.1f * step;
            scale -= Vector3.one * step;
            if (timePressed >= pressTime) // 如果按下时间超过阀值
            {
                
                color.a = Mathf.Clamp(color.a - step, 0f, 1f);
                shoot = true;
            }
            if (scaleY<=0.45)
            {
                scaleY = 0.45f;
            }
        }
        else
        {
            scale += Vector3.one * step;
            color.a = Mathf.Clamp(color.a + step, 0f, 1f);
            scaleY = starty;
        }

        scale = new Vector3(Mathf.Clamp(scale.x, 0.4f, 2.4f), Mathf.Clamp(scale.y, 0.4f, 2.4f), scale.z);
        msk.GetComponent<Transform>().localScale = scale;
        mouse.GetComponent<SpriteRenderer>().color = color;
        Arow.transform.localScale = new Vector3(Arow.transform.localScale.x, scaleY, Arow.transform.localScale.z);

        //print(shoot);
    }

    public void Reset()
    {
        shoot = false;
    }
}
