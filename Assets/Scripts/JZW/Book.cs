using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public Vector2 targetPosition;
    public float moveSpeed = 1f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        float progress = 0;
        Vector2 startPosition = rectTransform.anchoredPosition;

        while (progress < 1)
        {
            progress += Time.deltaTime * moveSpeed;
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, progress);
            yield return null;
        }
    }
}
