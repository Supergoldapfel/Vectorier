using UnityEngine;
using System.IO;

public class NewMapButtonScript : MonoBehaviour
{
    public GameObject newMapDialogue;
    public void onClick()
    {
        if (!Directory.Exists(Application.dataPath + "/Maps/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Maps/");
        }
        newMapDialogue.SetActive(true);
    }
}
