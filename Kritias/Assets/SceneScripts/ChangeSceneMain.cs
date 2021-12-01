using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMain : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Loading2Scene");
    }
}