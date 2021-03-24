using UnityEngine;

public class GridManager : MonoBehaviour
{
    WorldGrid worldGrid;
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        worldGrid = new WorldGrid(5, 5, 0.5f);
    }

    void Update()
    {
        //int highestPowerOf2 = (int)Mathf.Pow(2f, (int)(Mathf.Log(cam.orthographicSize) / Mathf.Log(2)));
        //float cellSize = highestPowerOf2 / 4;
        float cellSize = 1f;
        Vector3 endCamCorner = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Vector3 startCamCorner = cam.ScreenToWorldPoint(Vector3.zero);
        Vector3 gridEndPoint = new Vector3(Mathf.Ceil(endCamCorner.x), Mathf.Ceil(endCamCorner.y));
        Vector3 gridStartPoint = new Vector3(Mathf.Floor(startCamCorner.x), Mathf.Floor(startCamCorner.y));
        GameObject.Find("GridLines").transform.position = gridStartPoint;
        int gridSizeX = Mathf.CeilToInt((gridEndPoint.x - gridStartPoint.x) * (1 / cellSize));
        int gridSizeY = Mathf.CeilToInt((gridEndPoint.y - gridStartPoint.y) * (1 / cellSize));
        worldGrid.resize(gridSizeX, gridSizeY, cellSize);
    }
}
