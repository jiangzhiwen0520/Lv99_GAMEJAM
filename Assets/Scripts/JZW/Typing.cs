using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI originalText;
    public TextMeshProUGUI typedText;
   

    public string targetText;  //玩家需要输入的目标文本
    private int currentCharIndex;  //当前需要输入的字符索引

    //待输入文字变色，文字闪烁
    public Color newColor;

    public float blinkDuration = 0.75f;
    private bool isBlinking;

    public GameObject pressureController;
    public float failDuration = 0.1f;

    private char currentChar;
    // Start is called before the first frame update
    void Start()
    {
        targetText = "key words、My pronunciation also";
        currentCharIndex = 0;
        originalText.text = targetText;
        typedText.text = "";       

        //ChangeColorAt(currentCharIndex, newColor);
        StartCoroutine(BlinkChar());
    }

    // Update is called once per frame
    void Update()
    {
       

        targetText = targetText.Replace("<color=#FFFFFF>", "");
        targetText = targetText.Replace("</color>", "");
        if (currentCharIndex < targetText.Length)
        {
            currentChar= targetText[currentCharIndex];
        }



        if (Input.GetKeyDown((KeyCode)((int)currentChar ))|| Input.GetKeyDown((KeyCode)((int)currentChar+32)))
        {
            pressureController.GetComponent<PreesureController>().Award(2);
            if (currentCharIndex < targetText.Length)
            {
                //Debug.Log("按下按键");
                typedText.text += currentChar;
                currentCharIndex++;
                StartCoroutine(BlinkChar());

                //ChangeColorAt(currentCharIndex, newColor);

            }
            else
            {
                //Debug.Log("输入已满");
                GameObject.Find("生气老师(Clone)").GetComponent<AngryState>().enabled = false;
                GameObject.Find("AS").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("AS").GetComponent<Angry>().enabled = false;
                GameObject.Find("AM").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("AM").GetComponent<Angry>().enabled = false;
                GameObject.Find("AB").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("AB").GetComponent<Angry>().enabled = false;

                GameObject.Find("花1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("花1").GetComponent<Angry>().enabled = true;
                GameObject.Find("花2").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("花2").GetComponent<Angry>().enabled = true;
                GameObject.Find("花3").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("花3").GetComponent<Angry>().enabled = true;
                GameObject.Find("花4").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("花4").GetComponent<Angry>().enabled = true;

            }

        }
        else if (Input.anyKeyDown&&!Input.GetMouseButtonDown(0)&& !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2)&&!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown((KeyCode)((int)currentChar + 32)))
        {
            Debug.Log("fail");
            pressureController.GetComponent<PreesureController>().Punishment(2);
            StartCoroutine(fail());

        }




    }

    public void ChangeColorAt(int index, Color color)
    {
        string originStr = targetText;
        string colorHexCode = ColorUtility.ToHtmlStringRGBA(color);
        string coloredChar = $"<color=#{colorHexCode}>{originStr[index]}</color>";
        originalText.text = originStr.Substring(0, index) + coloredChar + originStr.Substring(index + 1);
    }

    private IEnumerator BlinkChar()
    {
        isBlinking = true;
        
        while (isBlinking)
        {
            if (currentCharIndex >= 0 && currentCharIndex < targetText.Length)
            {
                originalText.text = targetText.Substring(0, currentCharIndex) + "<color=#0000>" + targetText[currentCharIndex] + "</color>" + targetText.Substring(currentCharIndex + 1);
                yield return new WaitForSeconds(blinkDuration);

                originalText.text = targetText;
                yield return new WaitForSeconds(blinkDuration);

            }
            else
            {
                //Debug.LogError("Character index is out of range.");
                isBlinking = false;
            }
        }
    }
    private IEnumerator fail()
    {
        originalText.text = targetText.Substring(0, currentCharIndex) + "<color=#FF0000>" + targetText[currentCharIndex] + "</color>" + targetText.Substring(currentCharIndex + 1);
        yield return new WaitForSeconds(failDuration);

        originalText.text = targetText;
        

    }
}