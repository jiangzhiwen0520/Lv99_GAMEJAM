using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nerv : MonoBehaviour
{
    private float nVal;
    private Color color;
    public GameObject nerobj;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(nerobj.GetComponent<PreesureController>().GetPressurePoint());
    }

    // Update is called once per frame
    void Update()
    {

        nVal = nerobj.GetComponent<PreesureController>().GetPressurePoint();
        //Debug.Log(nVal);
        color = gameObject.GetComponent<Image>().color;
        
        
        color.a = nVal/100;  // 50% opacity
        gameObject.GetComponent<Image>().color = color;

    }
}
