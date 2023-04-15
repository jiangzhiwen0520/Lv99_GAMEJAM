using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("��Ϸ��������")]
    public GameObject gameOver;
    [Header("��Ϸ�ɹ�����")]
    public GameObject gameClear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Circle2>().GetTime() <= 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("BallEnd"))
        {
            //Debug.Log("��ײ");
            Cursor.visible = true;
            Time.timeScale = 0;
            gameClear.SetActive(true);
        }
        else if(other.gameObject.tag.Equals("Border"))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

}
