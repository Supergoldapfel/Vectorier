using System.Collections.Generic;
using UnityEngine;

public class WorldGrid
{
    public int width;
    public int height;
    private float cellSize;
    private Vector2[] gridPositions;
    private List<GameObject> gridLines = new List<GameObject>();
    private List<GameObject> borderLines = new List<GameObject>();

    public WorldGrid(int width, int height, float cellSize = 1f)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridPositions = calculateGridPositions(width, height);
        for (int i = 0; i < gridPositions.Length; i++)
        {
            gridLines.Add(drawLine(getWorldPosition(gridPositions[i]), new Vector3(0, cellSize)));
            gridLines.Add(drawLine(getWorldPosition(gridPositions[i]), new Vector3(cellSize, 0)));
        }
        
        borderLines.Add(drawLine(getWorldPosition(new Vector3(0, height)), getWorldPosition(new Vector3(width, 0))));
        borderLines.Add(drawLine(getWorldPosition(new Vector3(width, 0)), getWorldPosition(new Vector3(0, height))));
    }

    public Vector3 getWorldPosition(Vector2 gridPosition)
    {
        return new Vector3(gridPosition.x, gridPosition.y) * cellSize;
    }

    private Vector2[] calculateGridPositions(int xLength, int yLength)
    {
        Vector2[] newGridPositions = new Vector2[xLength * yLength];
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                newGridPositions[x * yLength + y] = new Vector2(x, y);
            }
        }
        return newGridPositions;
    }

    public void destroy()
    {
        foreach (GameObject line in GameObject.FindGameObjectsWithTag("GridLine"))
        {
            Object.Destroy(line);
        }
    }

    private void repositionLines(List<GameObject> repositionLines, Vector2[] repositionPositions)
    {
        for (int i = 0; i < repositionLines.Count; i += 2)
        {
            repositionLines[i].GetComponent<GridLineScript>().startPos = getWorldPosition(repositionPositions[i / 2]);
            repositionLines[i + 1].GetComponent<GridLineScript>().startPos = getWorldPosition(repositionPositions[i / 2]);
            repositionLines[i].GetComponent<GridLineScript>().endPos = getWorldPosition(repositionPositions[i / 2]) + new Vector3(0, cellSize);
            repositionLines[i + 1].GetComponent<GridLineScript>().endPos = getWorldPosition(repositionPositions[i / 2]) + new Vector3(cellSize, 0);
        }
    }

    private void repositionBorders(List<GameObject> repositionBorders, Vector3 endCorner)
    {
        repositionBorders[0].GetComponent<GridLineScript>().startPos = new Vector3(0, endCorner.y);
        repositionBorders[0].GetComponent<GridLineScript>().endPos = endCorner;
        repositionBorders[1].GetComponent<GridLineScript>().startPos = new Vector3(endCorner.x, 0);
        repositionBorders[1].GetComponent<GridLineScript>().endPos = endCorner;
    }

    public void resize(int newWidth, int newHeight, float newCellSize = -1f)
    {
        width = newWidth;
        height = newHeight;
        if(newCellSize != -1f)
        {
            cellSize = newCellSize;
        }
        gridPositions = calculateGridPositions(width, height);

        if(gridPositions.Length > gridLines.Count / 2)
        {
            repositionLines(gridLines, gridPositions);

            for (int i = gridLines.Count / 2; i < gridPositions.Length; i++)
            {
                gridLines.Add(drawLine(getWorldPosition(gridPositions[i]), new Vector3(0, cellSize)));
                gridLines.Add(drawLine(getWorldPosition(gridPositions[i]), new Vector3(cellSize, 0)));
            }

            repositionBorders(borderLines, getWorldPosition(new Vector2(width, height)));
        }
        else if(gridPositions.Length < gridLines.Count / 2)
        {
            for (int i = gridPositions.Length * 2; i < gridLines.Count; i += 2)
            {
                GameObject.Destroy(gridLines[i]);
                GameObject.Destroy(gridLines[i + 1]);
                gridLines[i] = null;
                gridLines[i + 1] = null;
            }
            gridLines.RemoveAll((g) => { return g == null; });

            repositionLines(gridLines, gridPositions);
            repositionBorders(borderLines, getWorldPosition(new Vector2(width, height)));
        }
    }

    private GameObject drawLine(Vector3 start, Vector3 offset)
    {
        GameObject line = new GameObject("GridLine");
        line.transform.SetParent(GameObject.FindGameObjectWithTag("GridLines").transform);
        line.transform.localPosition = Vector3.zero;
        LineRenderer lr = line.AddComponent<LineRenderer>();
        GridLineScript gs = line.AddComponent<GridLineScript>();
        gs.startPos = start;
        gs.endPos = start + offset;
        gs.width = 0.8f;
        line.tag = "GridLine";
        return line;
    }
}
