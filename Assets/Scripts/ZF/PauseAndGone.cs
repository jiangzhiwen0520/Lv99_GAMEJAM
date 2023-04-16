using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndGone : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    private int i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPauseClickDown()
    {
        Debug.Log("œÏ”¶");
        if (Input.GetKey(KeyCode.Space))
            return;

        GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(5);
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = !GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled;
        i = 1 - i;
        gameObject.GetComponent<Image>().sprite = sprites[i];
        Time.timeScale = 1 - Time.timeScale;


        //GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;

    }
    public void OnPauseClickUp()
    {
        //GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public void OnGoneClickDown()
    {
        //GetComponent<SpriteRenderer>().sprite = sprite2;
        //Time.timeScale = 1- Time.timeScale;
    }
    public void OnGoneClickUp()
    {
        //GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
