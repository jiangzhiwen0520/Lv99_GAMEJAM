using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI originalText;
    public TextMeshProUGUI typedText;
    public TextMeshProUGUI cursor;
    public RectTransform cursorRectTransform;


    public string targetText;  //玩家需要输入的目标文本
    private int currentCharIndex;  //当前需要输入的字符索引

    //光标闪烁
    private float cursorBlinkInterval = 0.5f;
    private float cursorBlinkTimer;
    private bool cursorVisible;


    // Start is called before the first frame update
    void Start()
    {
        targetText = "AABBFFCCCCCCCCCCCCCCCC";
        currentCharIndex = 0;
        originalText.text = targetText;
        typedText.text = "";
        cursor.text = "|";
        cursorBlinkTimer = 0;
        cursorVisible = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (currentCharIndex < targetText.Length)
        {
            char currentChar = targetText[currentCharIndex];
            if (Input.GetKeyDown((KeyCode)((int)currentChar + 32)))
            {
                typedText.text += currentChar;
                currentCharIndex++;

                // 更新光标位置
                //typedText.ForceMeshUpdate();
                TMP_TextInfo textInfo = originalText.textInfo;
                Debug.Log(textInfo.characterCount);
                Debug.Log(currentCharIndex);
                if (currentCharIndex < textInfo.characterCount)
                {
                    Debug.Log("更新位置");

                    TMP_CharacterInfo charInfo = textInfo.characterInfo[currentCharIndex - 1];
                    float cursorXPos = charInfo.topRight.x-160;
                    float cursorYPos = charInfo.bottomLeft.y+13;
                    int lineIndex = charInfo.lineNumber;

                    if (lineIndex > 0)
                    {
                        cursorYPos = textInfo.lineInfo[lineIndex].ascender;
                    }
                    Debug.Log(cursorXPos);
                    Debug.Log(cursorYPos);
                    cursorRectTransform.anchoredPosition = new Vector2(cursorXPos, cursorYPos);
                }
            }
        }

        // 光标闪烁逻辑
        cursorBlinkTimer += Time.deltaTime;
        if (cursorBlinkTimer >= cursorBlinkInterval)
        {
            cursorBlinkTimer = 0;
            cursorVisible = !cursorVisible;
            cursor.enabled = cursorVisible;
        }



    }
}