using Boo.Lang;
using System.IO;
using UnityEngine;

public class EditMapButtonScript : MonoBehaviour
{
    public List<Map> mapList = new List<Map>();

    public GameObject editMapDialogue;
    public void onClick()
    {
        if (!Directory.Exists(Application.dataPath + "/Maps/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Maps/");
        }
        string[] dir = Directory.GetDirectories(Application.dataPath + "/Maps/");

        for (int i = 0; i < dir.Length; i++)
        {
            mapList.Add(new Map(dir[i].Substring(dir[i].LastIndexOf("/") + 1)));
        }

        editMapDialogue.SetActive(true);
    }
}
