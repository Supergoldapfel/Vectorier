using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MapScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.parent.GetComponent<MapsViewportScript>().setNewSelected(gameObject);
    }

    public void setSelectedState(bool isSelected)
    {
        GetComponent<Image>().enabled = isSelected;
    }
}
