using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwinkleEffect : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;             //페이드 시간
    //private TextMeshProUGUI textFade;   //사용되는 TMPro
    private Text textFade;

    private void Awake()
    {
        //textFade = GetComponent<TextMeshProUGUI>();
        textFade = GetComponent<Text>();

        //Fade in-out 반복
        StartCoroutine(Twinkle());
    }

    private IEnumerator Twinkle()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));  //Fade in

            yield return StartCoroutine(Fade(0, 1)); //Fade out
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while ( percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = textFade.color;
            color.a = Mathf.Lerp(start, end, percent);
            textFade.color = color;

            yield return null;
        }
    }
}
