using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2Loading : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
}