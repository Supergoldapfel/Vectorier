using UnityEngine;

public class MousePanScript : MonoBehaviour
{
    public float panSensitivity = 0.01f;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Translate(-delta.x * panSensitivity, -delta.y * panSensitivity, 0f);
            lastMousePosition = Input.mousePosition;
        }
    }
}

