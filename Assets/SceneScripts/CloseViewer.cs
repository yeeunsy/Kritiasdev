using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum SystemClickType { Button }

public class CloseViewer : MonoBehaviour
{
    //[SerializeField]
    //private SystemTextViewer closeTextViewer;
    [SerializeField]
    private TextMeshProUGUI textSystem;

    private CloseAlpha closeAlpha;

    private Button button;

    private void Awake()
    {
        textSystem = GetComponent<TextMeshProUGUI>();
        closeAlpha = GetComponent<CloseAlpha>();
    }

    public void PrintCloseText(SystemClickType type)
    {
        switch (type)
        {
            case SystemClickType.Button:
                textSystem.text = "To be continued.";
                break;
        }

        closeAlpha.FadeOut();
    }
}