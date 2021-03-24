using UnityEngine;
using TMPro;

public class ConfirmXMLButtonScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public void onClick()
    {
        string path = inputField.text;
    }
}
