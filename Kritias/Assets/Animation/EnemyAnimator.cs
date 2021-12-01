using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    //private int currentIndex = 0;
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;
    private Animator anim;


    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    /*public void Setup()
    {
        while (true)
        {
            if ()
            {
                anim.SetTrigger("Right");
            }
        }
    }*/
}
