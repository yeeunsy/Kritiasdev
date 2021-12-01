using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Enemy enemy;
    //private int _totalEnemy = 0;

    private void Start()
    {

        DontDestroyOnLoad(gameObject);
        
        //enemy.OnDie(EnemyDestroyType.Kill) += AddTotalEnemy;
    }
   


    /*public void AddTotalEnemy()
    {
        _totalEnemy++;

        AchieveSc.Instance.OnNotify(
            AchieveSc.Achievements.Enemy10,
            totalEmemy: _totalEnemy
            );
    }*/
}
