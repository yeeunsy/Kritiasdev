using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutomng : MonoBehaviour
{
    //public TutorialManager tutorialManager;
    //public TutorialsItemControl tutorialsItemControl;

    public void TutorialMenu()
    {
        int tutorialsDone = PlayerPrefs.GetInt("TutorialsDone", 0);

        if (tutorialsDone == 0)
        {
            SceneManager.LoadScene("Tutorial");
            return;
        }
    }
}