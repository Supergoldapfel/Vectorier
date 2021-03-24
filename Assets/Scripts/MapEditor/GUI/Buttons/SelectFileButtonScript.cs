using SFB;
using TMPro;
using UnityEngine;

public class SelectFileButtonScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public void onClick()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select XML File", "", "xml", false);
        if (path.Length > 0)
        {
            inputField.SetTextWithoutNotify(path[0]);
        }
    }
}
