using UnityEngine;
using System.IO;
using TMPro;

public class ConfirmSetupButtonScript : MonoBehaviour
{
    public TMP_InputField pathInput;
    public TextMeshProUGUI info;
    public void onClick()
    {
        info.gameObject.SetActive(true);
        info.SetText("Loading...");
        info.color = Color.white;

        if(Directory.Exists(pathInput.text))
        {
            //Load Vector Data
        }
        else
        {
            info.color = Color.red;
            info.SetText("Directory does not exist!");
        }
    }
}
