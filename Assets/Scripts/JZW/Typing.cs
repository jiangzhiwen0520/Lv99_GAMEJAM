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
    //public GameObject teacher;

    public float failDuration = 0.1f;

    private char currentChar;

    private int firstLen;
    private int page;

    public GameObject sucP;
    public GameObject failP;

    //private bool isSpace;
    // Start is called before the first frame update
    void Start()
    {
        //isSpace = true;
        page = 1;
        targetText = "Last year, I did not like English class, Every class was like a bad dream, I just hid behind my textbook and never said anything. Then one day I watched an English  ";
        //firstLen = targetText.Length;
        currentCharIndex = 0;
        originalText.text = targetText;
       //Debug.Log(originalText.text);
        typedText.text = "";       

        //ChangeColorAt(currentCharIndex, newColor);
        StartCoroutine(BlinkChar());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (GameObject.Find("生气老师(Clone)") != null)
            {
                if (GameObject.Find("生气老师(Clone)").GetComponent<AngryState>().isAni)
                {

                    failP.SetActive(true);
                    Time.timeScale = 0.2f;
                }
            }



            if (page == 1)
            {
                if (currentCharIndex == targetText.Length - 2)
                {

                    page = 2;
                    targetText = "movie called Toy Story, I fell in love with this exciting and funny movie. So I began to watch other English movies as well. Although I could not understand  ";
                    originalText.text = targetText;
                    typedText.text = "";
                    currentCharIndex = 0;
                }

            }
            else if (page == 2)
            {
                if (currentCharIndex == targetText.Length - 2)
                {
                    page = 3;
                    targetText = "everything the characters said, their body language and the expressions on their faces helped me to get the meaning, I have loved English since then.  ";
                    originalText.text = targetText;
                    typedText.text = "";
                    currentCharIndex = 0;
                }

            }
            //else if (page == 3)
            //{
            //    if (currentCharIndex == targetText.Length)
            //    {
            //        page = 4;
            //        targetText = "listening for just the key words. I discovered that listening to some thing you are really interested in is the secret to language learning. Now I enjoy my English";
            //        typedText.text = "";
            //        currentCharIndex = 0;
            //    }

            //}
            //else if (page == 4)
            //{
            //    if (currentCharIndex == targetText.Length)
            //    {
            //        page = 5;
            //        targetText = "class, Then I can have a better understanding of English movies.";
            //        typedText.text = "";
            //        currentCharIndex = 0;
            //    }

            //}





            targetText = targetText.Replace("<color=#FFFFFF>", "");
            targetText = targetText.Replace("</color>", "");
            if (currentCharIndex < targetText.Length)
            {

                while (char.IsWhiteSpace(targetText[currentCharIndex]))
                {

                    currentCharIndex++;
                    //if (isSpace == true)
                    //{
                    typedText.text += " ";

                    //}
                    //else 
                    //{
                    //    isSpace=  !isSpace; 
                    //}

                }
                currentChar = targetText[currentCharIndex];

            }




            if (Input.GetKeyDown((KeyCode)((int)currentChar)) || Input.GetKeyDown((KeyCode)((int)currentChar + 32)))
            {
                GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(2);
                pressureController.GetComponent<PreesureController>().Award(2);
                if (GameObject.Find("生气老师(Clone)") != null)
                {
                    GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().Award(6);
                }

                Debug.Log(currentCharIndex);
                Debug.Log(targetText.Length);
                if (currentCharIndex < targetText.Length - 3)
                {
                    //Debug.Log("按下按键");

                    if (originalText.textInfo.characterInfo[currentCharIndex].lineNumber != originalText.textInfo.characterInfo[currentCharIndex + 2].lineNumber)
                    {
                        currentCharIndex++;
                        //typedText.text = typedText.text.Substring(0, typedText.text.Length-1);
                        typedText.text += currentChar + "<br>";

                    }
                    else
                    {
                        
                        typedText.text += currentChar;
                    }


                    currentCharIndex++;
                    StartCoroutine(BlinkChar());

                    //ChangeColorAt(currentCharIndex, newColor);

                }
                else
                {
                    if (page >= 1)
                    {
                        typedText.text += currentChar;
                        //Debug.Log("输入已满");
                        GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(6);
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

                        GameObject.Find("PressureController").GetComponent<PreesureController>().Award(GameObject.Find("PressureController").GetComponent<PreesureController>().GetPressurePoint());
                        GameObject.Find("PressureController").GetComponent<PreesureController>().enabled = false;
                        GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().Award(GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().GetPressurePoint());
                        GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().enabled = false;


                        sucP.SetActive(true);
                        Time.timeScale = 0.2f;
                    }


                }

            }
            else if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2) && !Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown((KeyCode)((int)currentChar + 32)) && !Input.GetKeyDown((KeyCode)((int)currentChar)))
            {
                //Debug.Log("fail");
                GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(3);
                pressureController.GetComponent<PreesureController>().Punishment(2);
                if (GameObject.Find("生气老师(Clone)") != null)
                {
                    GameObject.Find("生气老师(Clone)").GetComponent<PreesureController>().Punishment(2);
                }

                if (currentCharIndex < targetText.Length)
                {
                    StartCoroutine(fail());
                    
                }


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
                //Debug.LogError("Character index is out of range.");
                isBlinking = false;
            }
        }
    }
    private IEnumerator fail()
    {
        Debug.Log("输入错误");
        originalText.text = targetText.Substring(0, currentCharIndex) + "<color=#FF0000>" + targetText[currentCharIndex] + "</color>" + targetText.Substring(currentCharIndex + 1);
        yield return new WaitForSeconds(failDuration);

        originalText.text = targetText;
        

    }
}