using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ConfirmMapSeclectionButtonScript : MonoBehaviour
{
    public MapsViewportScript mapsViewport;

    public void onClick()
    {
        MenuData.selectedMap = mapsViewport.selectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        SceneManager.LoadScene("MapEditor");
    }
}
