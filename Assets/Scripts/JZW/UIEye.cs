using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEye : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PlayAni());
        // StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().CloseEyelids(2));
        StartCoroutine(GameStart());
    }

    // Update is called once per frame
    void Update()
    {

    }


    //private IEnumerator PlayAni()
    //{
    //    float t = 0f;
    //    while (true)
    //    {
    //        t = 0f;
    //        while (t < 20)
    //        {
    //            t += Time.deltaTime;

    //           // yield return new WaitForSeconds(2);
    //            //StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().OpenEyelids(1));
    //            yield return null;
    //        }
    //    }
    //}
    private IEnumerator GameStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().CloseEyelids(1));
            yield return new WaitForSeconds(1);
            StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().OpenEyelids(0.5f));
        }
        
        

    }
}