using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTime : MonoBehaviour
{
    Controller_Time ct;

    void Start()
    {
        ct = GetComponent<Controller_Time>();
    }

    public void OnMouseUp()
    {
        // 2배속
        if (ct.isFastSpeed == false)
        {
            ct.isFastSpeed = true;
            Time.timeScale = 2f;
        }
        // 1배속
        else
        {
            ct.isFastSpeed = false;
            Time.timeScale = 1f;
        }
    }
}
