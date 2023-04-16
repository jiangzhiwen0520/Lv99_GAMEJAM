using UnityEngine;

public class FloatingImage : MonoBehaviour
{
    public float amplitude = 20f; // 浮动的振幅
    public float speed = 1f; // 浮动的速度
    private Vector2 initialPosition; // 初始位置

    private void Start()
    {
        initialPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        float newY = initialPosition.y + amplitude * Mathf.Sin(Time.time * speed);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(initialPosition.x, newY);
    }
}

