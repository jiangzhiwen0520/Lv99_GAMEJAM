using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPanel : MonoBehaviour
{
    public Button btn_nextLevel, btn_quit, btn_Back;
    [Header("下一关按钮跳转的场景")]
    public string nextLevelScene;
    private void Awake()
    {
        //GameObject.Find("Timer").SetActive(false);
        
        btn_nextLevel.onClick.AddListener(() =>
        {
            
            Debug.Log("下一关");
            Scene scene = SceneManager.GetActiveScene();
            nextLevelScene = scene.name;
            if (nextLevelScene.Equals("UI"))
            {
                SceneManager.LoadScene("Scene01");
            }
            else
            {
                string s = nextLevelScene.Substring(0, nextLevelScene.Length - 1);
                string l = nextLevelScene.Substring(nextLevelScene.Length - 1, 1);
                nextLevelScene = s + (Convert.ToInt32(l) + 1);
                if (nextLevelScene.Equals("Scene05"))
                {
                    nextLevelScene = "Scene04";
                }
                SceneManager.LoadScene(nextLevelScene);

            }
           
            Time.timeScale = 1;
        });
        if (btn_quit != null)
        {
            btn_quit.onClick.AddListener(() =>
            {
                Scene scene = SceneManager.GetActiveScene();
                nextLevelScene = scene.name;
                SceneManager.LoadScene(nextLevelScene);
                Time.timeScale = 1;
            });
        }
        
        btn_Back.onClick.AddListener(() =>
        {
            
            Scene scene = SceneManager.GetActiveScene();
            nextLevelScene = scene.name;
            if (nextLevelScene.Equals("UI"))
            {
                UnityEngine.Application.Quit();
            }
            else 
            {
                SceneManager.LoadScene("UI");
                Time.timeScale = 1;
            }

        });
    }
}
