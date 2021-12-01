using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mgr : MonoBehaviour
{
    [SerializeField]
    InputField inputFieldID; //string
    [SerializeField]
    InputField inputFieldPW;
    //[SerializeField]
    //Slider slider; //Float

    public void Save()
    {
        PlayerPrefs.SetString("StringID", inputFieldID.text);
        PlayerPrefs.SetString("StringPW", inputFieldPW.text);
        //PlayerPrefs.SetFloat("SliderA", slider.value);
    }

    public void Load()
    {
        inputFieldID.text = PlayerPrefs.GetString("StringID");
        inputFieldPW.text = PlayerPrefs.GetString("StringPW");
        //slider.value = PlayerPrefs.GetFloat("SliderA");
    }
}
