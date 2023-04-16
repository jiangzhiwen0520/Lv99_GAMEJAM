using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryState : MonoBehaviour
{
    private float aValue;
    public GameObject vPanel;
    // Start is called before the first frame update
    void Start()
    {
        vPanel = GameObject.Find("FailPanel");
        gameObject.GetComponent<PreesureController>().Punishment(50);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(aValue);
        aValue= gameObject.GetComponent<PreesureController>().GetPressurePoint();
        if (aValue > 0 && aValue < 50)
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AS").GetComponent<Angry>().enabled = false;
            GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AM").GetComponent<Angry>().enabled = false;
            GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AB").GetComponent<Angry>().enabled = false;
        }
        else if (aValue < 100)
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AS").GetComponent<Angry>().enabled = true;
            GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AM").GetComponent<Angry>().enabled = false;
            GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AB").GetComponent<Angry>().enabled = false;

        }
        else if (aValue < 150)
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AS").GetComponent<Angry>().enabled = true;
            GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AM").GetComponent<Angry>().enabled = true;
            GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AB").GetComponent<Angry>().enabled = false;

        }
        else if (aValue < 200)
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AS").GetComponent<Angry>().enabled = true;
            GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AM").GetComponent<Angry>().enabled = true;
            GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AB").GetComponent<Angry>().enabled = true;
        }
        else if(aValue >= 200)
        {
            for (int i = 0; i < vPanel.transform.childCount; i++)
            {
                vPanel.transform.GetChild(i).GetComponent<Image>().enabled = true;
                vPanel.transform.GetChild(i).GetComponent<Angry>().enabled = true;

                GameObject.Find("PressureController").GetComponent<PreesureController>().Award(GameObject.Find("PressureController").GetComponent<PreesureController>().GetPressurePoint());
                GameObject.Find("PressureController").GetComponent<PreesureController>().enabled = false;
                gameObject.GetComponent<PreesureController>().Award(gameObject.GetComponent<PreesureController>().GetPressurePoint());
                gameObject.GetComponent<PreesureController>().enabled = false;
                
            }
        }

    }
}
