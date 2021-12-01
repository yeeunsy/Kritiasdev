using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public PlayerPrefs playerPrefs;
    
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