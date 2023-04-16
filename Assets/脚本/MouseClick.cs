using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private MouseChoose mouseChooseScript;
    [SerializeField] private GameObject BackCircle;
    [SerializeField] private Text text;
    [SerializeField] private Text text2;
    private bool isTrue = false;

    private int score = 0;
    private int chance = 0;
    private float Pime=60f;

    public GameObject gameOver;
    public GameObject fail;
    private void Start()
    {
        mouseChooseScript = GetComponent<MouseChoose>();
        text.text = $"分数:{score}";
    }

    void Update()
    {
        if (chance < 3)
        {
            Pime -= Time.deltaTime;
            if (mouseChooseScript != null && Input.GetMouseButtonUp(0) && mouseChooseScript.shoot)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    //GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(1);
                    //GameObject.Find("AudioController").GetComponent<AudioController>().PlayAudio(0);
                    chance += 1;
                    Pime = 60f;
                    //isShoot = true;
                    if (hit.collider.CompareTag("1h"))
                    {
                        Debug.Log("您的环为1");
                        isTrue = true;
                        Instantiate(BackCircle, hit.point, Quaternion.identity);
                        score += 10;

                    }
                    if (hit.collider.CompareTag("2h"))
                    {
                        Debug.Log("您的环为2");
                        isTrue = true;
                        Instantiate(BackCircle, hit.point, Quaternion.identity);
                        score += 9;
                    }
                    if (hit.collider.CompareTag("3h"))
                    {
                        Debug.Log("您的环为3");
                        isTrue = true;
                        Instantiate(BackCircle, hit.point, Quaternion.identity);
                        score += 8;
                    }
                    if (hit.collider.CompareTag("4h"))
                    {
                        Debug.Log("您的环为4");
                        isTrue = true;
                        Instantiate(BackCircle, hit.point, Quaternion.identity);
                        score += 7;
                    }
                    if (hit.collider.CompareTag("5h"))
                    {
                        Debug.Log("您的环为5");
                        isTrue = true;
                        Instantiate(BackCircle, hit.point, Quaternion.identity);
                        score += 6;
                    }
                    if (!isTrue)
                    {
                        Debug.Log("您未能射中");
                        score = 0;
                    }
                }
                else
                {
                    chance+=1;
                    Debug.Log("您未能射中");
                    score = 0;
                }

                mouseChooseScript.Reset();
            }
            text.text = $"分数: {score}";
            text2.text = $"时间: {Pime}";
        }
        if (chance==3)
        {
            if (score >= 24)
            {
                print("成功");
                gameOver.SetActive(true);
            }
            else
            {
                print("失败");
                fail.SetActive(true);
            }
        }
        if (Pime<=0)
        {
            print("失败");
        }
        
    }

   // private IEnumertor 
}
