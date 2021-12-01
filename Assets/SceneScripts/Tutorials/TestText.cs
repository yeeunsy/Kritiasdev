using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite jelfie;
}

public class TestText : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite_Jelfie;
    [SerializeField]
    private SpriteRenderer sprite_Dialogue;
    [SerializeField]
    private Text txt_Dialogue;
    [SerializeField]
    private Button btn_button;
    [SerializeField]
    private Button btn_isNextbutton;

    private bool isDialogue = false;
    private bool isNextScene = true;
    //private bool touchOn; //touchCount == 1

    private int count = 0;

    [SerializeField]
    private Dialogue[] dialogue;

    public void ShowDialogue()
    {
        OnOff(true);
        NextDialogue();
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_Jelfie.sprite = dialogue[count].jelfie;
        count++;
        HideDialogue();
    }

    private void HideDialogue()
    {
        btn_button.gameObject.SetActive(false);
    }
    private void OnOff(bool _flag)
    {
        sprite_Dialogue.gameObject.SetActive(_flag);
        sprite_Jelfie.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    void Update()
    {
        if (isDialogue)
        {
            if (Input.anyKeyDown)
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                    NextScene();
            }
        }
    }

    public void NextScene()
    {
        if (isNextScene)
        {
            if (count == dialogue.Length)
                btn_isNextbutton.gameObject.SetActive(true);
        }
    }

    public void NextBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
}