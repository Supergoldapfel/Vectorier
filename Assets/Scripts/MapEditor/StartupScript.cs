using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    private void Awake()
    {
        if(MenuData.selectedMap != null)
        {
            Debug.Log("Loaded Map: " + MenuData.selectedMap);
        }
    }
}
