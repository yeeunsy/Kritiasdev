using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRange : MonoBehaviour
{
    public void Awake()
    {
        OffTileRange();
    }

    public void OnTileRange()
    {
        gameObject.SetActive(true);

        //float diameter = tileRange * 2.0f;
        //transform.localScale = Vector3.one * diameter;
        
        //transform.position = position;
    }

    public void OffTileRange()
    {
        gameObject.SetActive(false);
    }

}
