using UnityEngine;

public class GridLineScript : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float width;

    void Update()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = startPos + transform.position;
        positions[1] = endPos + transform.position;
        if ((positions[0].x == 0 && positions[1].x == 0) | (positions[0].y == 0 && positions[1].y == 0))
        {
            GetComponent<LineRenderer>().material = transform.parent.GetComponent<GridLinesScript>().gridAxisMaterial;
        }
        else if((positions[0].x % 10 == 0 && positions[0].x == positions[1].x) | (positions[0].y % 10 == 0 && positions[0].y == positions[1].y))
        {
            GetComponent<LineRenderer>().material = transform.parent.GetComponent<GridLinesScript>().gridAltMaterial;
        }
        else
        {
            GetComponent<LineRenderer>().material = transform.parent.GetComponent<GridLinesScript>().gridMaterial;
        }
        GetComponent<LineRenderer>().SetPositions(positions);
        GetComponent<LineRenderer>().widthCurve = AnimationCurve.Linear(0f, Camera.main.orthographicSize * 0.01f * width, 0f, Camera.main.orthographicSize * 0.01f * width);
    }
}
