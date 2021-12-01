using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLoadingScene : MonoBehaviour
{
    public Slider slider;
    bool IsDone = false;
    float fTime = 0f;
    AsyncOperation async_operation;

    void Start()
    {
        StartCoroutine(StartLoad("MainMenuScene"));
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 4)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }
    }
}
