using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithBox : MonoBehaviour
{
    //textԤ����
    public GameObject TextType;
    //����text�����ö���
    //private GameObject go;
    // Start is called before the first frame update
    private void Start()
    {
        //go = Instantiate(TextType, GameObject.FindGameObjectWithTag("canvas").transform);
    }
    private void Update()
    {

        TextType.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
