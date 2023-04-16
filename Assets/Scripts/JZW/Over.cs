using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Over : MonoBehaviour
{
    public float rotationSpeed;

    public float blinkSpeed = 1f;  //��˸���ٶ�
    public float blinkDuration = 1f;  //��˸�ĳ���ʱ��

    public GameObject back;
    private Image image;  //Image���
    private Color originalColor;  //ԭʼ��ɫ
    private Color blinkColor;  //��˸��ɫ
    // Start is called before the first frame update
    void Start()
    {
        //��ȡImage���
        image = back.GetComponent<Image>();

        //��¼ԭʼ��ɫ
        originalColor = image.color;

        //������˸��ɫ��alphaֵΪ0
        blinkColor = originalColor;
        blinkColor.a = 0;

        //������˸Э��
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
          this.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
    }

    //��˸Э��
    IEnumerator Blink()
    {
        while (true)
        {
            //����
            while (image.color.a > 0)
            {
                image.color -= new Color(0, 0, 0, blinkSpeed) * Time.deltaTime;
                yield return null;
            }

            //����
            while (image.color.a < 1)
            {
                image.color += new Color(0, 0, 0, blinkSpeed) * Time.deltaTime;
                yield return null;
            }

            //�ȴ���˸����ʱ��
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
