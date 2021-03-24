using TMPro;
using UnityEngine;

public class MapsViewportScript : MonoBehaviour
{
    public EditMapButtonScript editMap;
    public GameObject originalMap;

    public GameObject selectedGameObject;

    void Awake()
    {
        for (int i = 0; i < editMap.mapList.Count; i++)
        {
            GameObject clone = Instantiate(originalMap);
            clone.transform.SetParent(originalMap.transform.parent);
            clone.transform.position = originalMap.transform.position;
            clone.transform.localScale = originalMap.transform.localScale;
            clone.transform.Find("MapName").GetComponent<TextMeshProUGUI>().SetText(editMap.mapList[i].mapName);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y - i * (clone.transform.localScale.y * 1.2f), clone.transform.position.y);
            clone.SetActive(true);
        }
        transform.Find("Content").position = new Vector3(0f, (transform.parent.localScale.y - (editMap.mapList.Count * originalMap.transform.localScale.y)) / 2);
    }

    public void setNewSelected(GameObject newSelectedGameObject)
    {
        if (selectedGameObject)
        {
            selectedGameObject.GetComponent<MapScript>().setSelectedState(false);
        }
        selectedGameObject = newSelectedGameObject;
        selectedGameObject.GetComponent<MapScript>().setSelectedState(true);
    }
}
