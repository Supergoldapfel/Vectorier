using UnityEngine;
using SFB;
using TMPro;

public class SelectFolderButtonScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public void onClick()
    {
        var path = StandaloneFileBrowser.OpenFolderPanel("Select vector folder", "", false);
        if (path.Length > 0)
        {
            inputField.SetTextWithoutNotify(path[0]);
        }
    }
}
