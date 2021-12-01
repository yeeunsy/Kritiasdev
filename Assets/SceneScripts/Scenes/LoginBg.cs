using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoginBg : MonoBehaviour
{
    [SerializeField]
    private float goalRange = -192.71f;
    //[SerializeField]
    //private float scrollRange = -207.29f;
    [SerializeField]
    private float moveSpeed = 0.7f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        // 디렉션 방향으로 스피드의 속도로 이동
        transform.position -= moveDirection * moveSpeed * Time.deltaTime;

        if ( transform.position.y <= goalRange )
        {
            moveSpeed = 0.0f;
        }
    }
}
