using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private Transform targetMouse;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        targetMouse.position = mainCamera.ScreenToWorldPoint(mousePos);
    }
}
