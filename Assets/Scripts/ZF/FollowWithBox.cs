using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithBox : MonoBehaviour
{
    //textԤ����
    //public GameObject TextType;
    //����text�����ö���
    public GameObject go;
    // Start is called before the first frame update
    private void Start()
    {
        //go = Instantiate(TextType, GameObject.FindGameObjectWithTag("canvas").transform);
    }
    private void Update()
    {

        if(go!=null)
            //GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(go.transform.position);
            transform.position =  Camera.main.WorldToScreenPoint(go.transform.position); 
    }
}
