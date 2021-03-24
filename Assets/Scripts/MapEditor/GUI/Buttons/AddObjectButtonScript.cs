using UnityEngine;

public class AddObjectButtonScript : MonoBehaviour
{
    public GameObject AddObjectDialogue;
    public void onClick()
    {
        AddObjectDialogue.SetActive(true);
    }
}
