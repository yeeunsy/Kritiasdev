using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutoset : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer panel;

    private void Update()
    {
        if ( Input.anyKeyDown )
        {
            panel.gameObject.SetActive(false);
        }
    }
}
