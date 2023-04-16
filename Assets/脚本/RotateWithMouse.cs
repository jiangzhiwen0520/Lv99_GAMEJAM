using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; //将鼠标的屏幕坐标深度设置为10
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}