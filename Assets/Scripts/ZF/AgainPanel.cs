using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgainPanel : MonoBehaviour
{
    public Button btn_nextLevel, btn_quit, btn_Back;
    [Header("重新开始场景")]
    public string nextLevelScene;
    private void Awake()
    {
        btn_nextLevel.onClick.AddListener(() =>
        {
            //Debug.Log("下一关");
            Scene scene = SceneManager.GetActiveScene();
            nextLevelScene = scene.name;
            /*string s = nextLevelScene.Substring(0, nextLevelScene.Length - 1);
            string l = nextLevelScene.Substring(nextLevelScene.Length - 1, 1);
            nextLevelScene = s + (Convert.ToInt32(l) + 1);
            if (nextLevelScene.Equals("Scene_05"))
            {
                nextLevelScene = "Scene_04";
            }*/
            Time.timeScale = 1;
            SceneManager.LoadScene(nextLevelScene);
        });
        btn_quit.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("UI");

        });
        btn_Back.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("UI");

        });
    }
}
