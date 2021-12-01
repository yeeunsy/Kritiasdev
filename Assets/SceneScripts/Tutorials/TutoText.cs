using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutoText : MonoBehaviour
{
    Text text;

    void Awake()
    {
        StartCoroutine(FadeTextToFullAlphaOne());
    }

    public IEnumerator FadeTextToFullAlphaOne() // 알파값 0에서 1로 전환
    {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 5.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroOne());
    }

    public IEnumerator FadeTextToZeroOne()  // 알파값 1에서 0으로 전환
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 5.0f));
            yield return null;
        }
        Start();
    }

    void Start()
    {
        Invoke("NextScene", 11);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    /*public IEnumerator FadeTextToFullAlphaTwo() // 알파값 0에서 1로 전환
    {
        text2 = GetComponent<Text>();
        text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, 0);
        while (text2.color.a < 1.0f)
        {
            text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, text2.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroTwo());
    }

    public IEnumerator FadeTextToZeroTwo()  // 알파값 1에서 0으로 전환
    {
        text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, 1);
        while (text2.color.a > 0.0f)
        {
            text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, text2.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }*/
}