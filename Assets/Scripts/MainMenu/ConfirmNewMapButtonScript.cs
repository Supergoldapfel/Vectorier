using UnityEngine;
using System.IO;
using TMPro;

public class ConfirmNewMapButtonScript : MonoBehaviour
{
    public TextMeshProUGUI nameInput;
    public GameObject newMapDialogue;

    public void onClick()
    {
        if(nameInput.text.IndexOfAny(Path.GetInvalidFileNameChars()) == -1 && !Directory.Exists(Application.dataPath + "/Maps/" + nameInput.text))
        {
            Directory.CreateDirectory(Application.dataPath + "/Maps/" + nameInput.text);
            if (Directory.Exists(Application.dataPath + "/Maps/" + nameInput.text))
            {
                File.Create(Application.dataPath + "/Maps/" + nameInput.text + "/Custom_" + nameInput.text + ".xml");
                newMapDialogue.SetActive(false);
            }
        }
        else
        {
            //Map already exists or invalid name
        }
    }
}
