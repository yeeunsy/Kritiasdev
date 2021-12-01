using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTSpawn : MonoBehaviour
{
    [SerializeField]
    private CloseViewer closeViewer; //닫힌 버튼을 눌렀을 경우 출력
    private bool isOnCloseButton = false; //닫힌 버튼 눌렀는지 확인
    private int buttonType;  //버튼

    public void CloseTxtSpawn(int type)
    {
        buttonType = type;

        if (isOnCloseButton == true )
        {
            closeViewer.PrintCloseText(SystemClickType.Button);
            return;
        }
    }
}
