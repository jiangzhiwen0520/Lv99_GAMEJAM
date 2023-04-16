using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithBox : MonoBehaviour
{
    //text预制体
    //public GameObject TextType;
    //生成text的引用对象
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
