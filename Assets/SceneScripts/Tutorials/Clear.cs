using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.UGUI;

[System.Serializable]
public class Tutorial
{
    [TextArea]
    public string sctdial;
    public Sprite jelfiecg;
}
public class Clear : MonoBehaviour
{
    //[SerializeField]
    //private TowerTemplate towerTemplate; //타워 정보
    [SerializeField]
    private SpriteRenderer Sprite_Jelfie;
    [SerializeField]
    private SpriteRenderer Sprite_Box;
    [SerializeField]
    private Text txt_Dialogue;
    [SerializeField]
    private Button btn_Nextbutton;
    [SerializeField]
    private Button btn_button;

    private bool isDialogue = false;

    private int count = 0;

    public int tutorialCount = 0;  //현재 시작한 경우 튜토리얼을 했는지 확인한다. (현재 튜토리얼 진행은 0이다.)
    public int maxtutorialCount = 1;

    [SerializeField]
    private Tutorial[] dialogue;

    private bool isNextScene = true;


    public void ClearDial()
    {
        OnOff(true);
        NextDialogue();
    }

    private void OnOff(bool _flag)
    {
        Sprite_Box.gameObject.SetActive(_flag);
        Sprite_Jelfie.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }


    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].sctdial;
        Sprite_Jelfie.sprite = dialogue[count].jelfiecg;
        count++;
        HideDialogue();
    }

    private void HideDialogue()
    {
        btn_button.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isDialogue)
        {
            if (Input.anyKeyDown)
            {
                if (count < dialogue.Length)
                {
                    NextDialogue();
                }
                else
                {
                    ClearNextScene();
                }
            }
        }
    }

    public void ClearNextScene()
    {
        if (isNextScene)
        {
            if (count == dialogue.Length)
                btn_Nextbutton.gameObject.SetActive(true);
        }
    }

    public void ClearBtn()
    {
        SceneManager.LoadScene("MainMenuScene");
        tutorialCount++;
    }

    /*private void HideDialogue()
    {
        btn_button.gameObject.SetActive(false);
    }*/
}
