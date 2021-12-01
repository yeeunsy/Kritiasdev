using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    //[SerializeField]
    private int currentExp = 0;
	//private int level = 0;

	public int CurrentExp
    {
        set => currentExp = Mathf.Max(0, value);
        get => currentExp;
    }
	

	/*public void Awake()
    {
        if ()
    }*/
}
