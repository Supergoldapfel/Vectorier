using UnityEngine;

public class MouseScrollScript : MonoBehaviour
{
    public float scrollScale = 0.1f;

    void Update()
    {
        Camera.main.orthographicSize += Input.mouseScrollDelta.y * scrollScale;
    }
}
