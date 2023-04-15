using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : MonoBehaviour
{
    private float aValue;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<PreesureController>().Punishment(50);
    }

    // Update is called once per frame
    void Update()
    {
        aValue= gameObject.GetComponent<PreesureController>().GetPressurePoint();
        if (aValue > 0 && aValue < 50)
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled=false;
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
        else
        {
            GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AS").GetComponent<Angry>().enabled = true;
            GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AM").GetComponent<Angry>().enabled = true;
            GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("AB").GetComponent<Angry>().enabled = true;
        }
            

    }
}
