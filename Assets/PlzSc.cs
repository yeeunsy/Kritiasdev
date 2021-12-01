using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlzSc : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.Button("Press Me !");
        Debug.Log("id : " + GUIUtility.hotControl);
    }
}
