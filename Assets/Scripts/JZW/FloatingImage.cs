using UnityEngine;

public class FloatingImage : MonoBehaviour
{
    public float amplitude = 20f; // ���������
    public float speed = 1f; // �������ٶ�
    private Vector2 initialPosition; // ��ʼλ��

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

