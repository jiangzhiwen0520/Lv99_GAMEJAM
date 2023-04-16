using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EyelidCloseEffect : MonoBehaviour
{
    public Image topEyelid;
    public Image bottomEyelid;
    //public float closeDuration = 1f;

    Vector2 initialTopPosition ;
    Vector2 initialBottomPosition;

    private void Start()
    {
        //StartCoroutine(CloseEyelids());
        initialTopPosition = topEyelid.rectTransform.anchoredPosition;
        initialBottomPosition = bottomEyelid.rectTransform.anchoredPosition;
    }

    public IEnumerator CloseEyelids(float time)
    {
        float progress = 0f;
       
        Vector2 closedPosition = Vector2.zero;

        while (progress < 1f)
        {
            progress += Time.deltaTime / time;
            topEyelid.rectTransform.anchoredPosition = Vector2.Lerp(initialTopPosition, closedPosition, progress);
            bottomEyelid.rectTransform.anchoredPosition = Vector2.Lerp(initialBottomPosition, closedPosition, progress);
            yield return null;
        }
    }

    public IEnumerator OpenEyelids(float time)
    {
        //Debug.Log("еібл");
        float progress = 0f;
        
        Vector2 closedPosition = Vector2.zero;

        while (progress < 1f)
        {
            progress += Time.deltaTime / time;
            topEyelid.rectTransform.anchoredPosition = Vector2.Lerp(closedPosition, initialTopPosition, progress);
            bottomEyelid.rectTransform.anchoredPosition = Vector2.Lerp(closedPosition, initialBottomPosition, progress);
            yield return null;
        }
    }

}
