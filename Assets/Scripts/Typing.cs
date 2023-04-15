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


    // Start is called before the first frame update
    void Start()
    {
        targetText = "AABBFFCCCCCCCCCCCCCCCC";
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
        char currentChar = targetText [currentCharIndex];
        if (Input.GetKeyDown((KeyCode)((int)currentChar + 32)))
        {
            if (currentCharIndex < targetText.Length)
            {
                Debug.Log("按下按键");
                typedText.text += currentChar;
                currentCharIndex++; 
                StartCoroutine(BlinkChar());
                
                //ChangeColorAt(currentCharIndex, newColor);

            }
            else
            {
                Debug.Log("输入已满");
            }
            
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
                Debug.LogError("Character index is out of range.");
                isBlinking = false;
            }
        }
    }
}