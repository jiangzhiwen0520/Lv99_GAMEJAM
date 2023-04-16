using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Over : MonoBehaviour
{
    public float rotationSpeed;

    public float blinkSpeed = 1f;  //闪烁的速度
    public float blinkDuration = 1f;  //闪烁的持续时间

    public GameObject back;
    private Image image;  //Image组件
    private Color originalColor;  //原始颜色
    private Color blinkColor;  //闪烁颜色
    // Start is called before the first frame update
    void Start()
    {
        //获取Image组件
        image = back.GetComponent<Image>();

        //记录原始颜色
        originalColor = image.color;

        //设置闪烁颜色的alpha值为0
        blinkColor = originalColor;
        blinkColor.a = 0;

        //启动闪烁协程
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
          this.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
    }

    //闪烁协程
    IEnumerator Blink()
    {
        while (true)
        {
            //淡出
            while (image.color.a > 0)
            {
                image.color -= new Color(0, 0, 0, blinkSpeed) * Time.deltaTime;
                yield return null;
            }

            //淡入
            while (image.color.a < 1)
            {
                image.color += new Color(0, 0, 0, blinkSpeed) * Time.deltaTime;
                yield return null;
            }

            //等待闪烁持续时间
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
