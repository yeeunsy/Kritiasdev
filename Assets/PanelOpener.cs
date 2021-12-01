using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject InventoryUI;  

    public void OpenPanel()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(true);
        }
    }
}
