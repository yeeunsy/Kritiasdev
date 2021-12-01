using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    GameObject go_UI;

    [SerializeField] private float maxCount;
    //private float maxCount = 6;
    private float currentCount;

    //public float MaxCount => maxCount;
    //public float CurrentCount => currentCount;

    private void Awake()
    {
        currentCount = maxCount;
    }

    public void TakeCount(int hit)
    {
        currentCount -= hit;

        if (currentCount <= 0)
        {
            ShowClearUI();
        }
    }

    public void ShowClearUI()
    {
        //towerSpawner.SetActive(false);
        go_UI.SetActive(true);
    }
    public void NextBtn()
    {
        //Stages[currentStage++].SetActive(false);
        //Stages[currentStage].SetActive(true);
        go_UI.SetActive(false);
        //towerSpawner.SetActive(true);
    }
}
