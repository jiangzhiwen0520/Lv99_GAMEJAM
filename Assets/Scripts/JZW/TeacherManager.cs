using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherManager : MonoBehaviour
{
    public float time1;
    public float time2;
    public float time3;
    public float time4;
    public float time5;
    public float time6;
    public GameObject aTeacher;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(time1);
        StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().CloseEyelids(1));
        yield return new WaitForSeconds(time2);
        StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().OpenEyelids(1));
        yield return new WaitForSeconds(time3);

        StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().CloseEyelids(4));
        yield return new WaitForSeconds(time4);
        Destroy(GameObject.Find("老师"));

        GameObject.Instantiate(aTeacher, new Vector3(5.22f, 0.71f, 0f), Quaternion.identity);
        StartCoroutine(GameObject.Find("CloseEyes").GetComponent<EyelidCloseEffect>().OpenEyelids(0.5f));
        yield return new WaitForSeconds(time5);
        GameObject.Find("PressureController").GetComponent<PreesureController>().enabled = true;
        GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().enabled = true;
        GameObject.Find("课本").GetComponent<Book>().enabled = true;

    }
}