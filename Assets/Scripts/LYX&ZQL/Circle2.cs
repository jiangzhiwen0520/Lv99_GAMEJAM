using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Circle2 : MonoBehaviour
{
    [SerializeField] private GameObject circle;
    [SerializeField] private UnityEngine.Camera mainCamera;
    [SerializeField] private Transform postransform;

    private CinemachineBrain cinemachineBrain;
    private bool isstart = false;

    void Start()
    {
        Cursor.visible = false;
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
        circle.transform.position = postransform.position;
    }

    void Update()
    {
        Cursor.visible = false;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isstart = true;
        }

        if (isstart)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = 10f;

            // 从 CinemachineBrain 获取当前渲染的相机
            UnityEngine.Camera currentCamera = cinemachineBrain.OutputCamera;
            Vector3 mouseWorldPosition = currentCamera.ScreenToWorldPoint(mouseScreenPosition);

            circle.transform.position = mouseWorldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            print("你已经死了");
        }
    }
}
