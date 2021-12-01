using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePause : MonoBehaviour
{
    Controller_Time ct;
    void Start()
    {
        ct = GetComponent<Controller_Time>();
    }

    public void OnMouseUp()
    {
        if (ct.isPause == false)
        {
            ct.isPause = true;
            Time.timeScale = 0f;
        }
        else
        {
            ct.isPause = false;
            Time.timeScale = 1f;
        }
    }
}