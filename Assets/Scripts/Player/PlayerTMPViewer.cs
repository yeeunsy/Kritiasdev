using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTMPViewer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textPlayerExp;
    [SerializeField]
    private PlayerExp playerExp;
    //[SerializeField]
    //private 


    private void Update()
    {
        textPlayerExp.text = playerExp.CurrentExp.ToString();
    }
}
