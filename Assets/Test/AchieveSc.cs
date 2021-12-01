using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AchieveSc : MonoBehaviour
{
    public enum Achievements
    {
        Enemy10,
        Stage5,
    }

    class AchievementsComparer : IEqualityComparer<Achievements>
    {
        public bool Equals(Achievements a, Achievements b)
        {
            return a == b;
        }

        public int GetHashCode(Achievements obj)
        {
            return ((int)obj).GetHashCode();
        }
    }

    static AchieveSc _instance;

    public static AchieveSc Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("AchieveSc");
                _instance = obj.AddComponent<AchieveSc>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    Dictionary<Achievements, bool> _dicAchievementUnlock =
        new Dictionary<Achievements, bool>(new AchievementsComparer());

    public void OnNotify(Achievements achv, int onstage = 0, int totalEnemy = 0)
    {
        switch(achv)
        {
            case Achievements.Stage5:
                UnlockStage5(onstage);
                break;
            case Achievements.Enemy10:
                UnlockEnemy10(totalEnemy);  
                break;
        }
    }

    public AchieveSc()
    {
        foreach(Achievements achv in Enum.GetValues(typeof(Achievements)))
        {
            _dicAchievementUnlock[achv] = false;
        }
    }

    void UnlockEnemy10(int totalEnemy)
    {
        if (_dicAchievementUnlock[Achievements.Enemy10])
            return;

        else if (totalEnemy >= 10)
        {
            Debug.Log("적 10명 죽이기 성공 !");
            _dicAchievementUnlock[Achievements.Enemy10] = true;
            //StartCoroutine(Cor_ShowText5Sec("적 10명 죽이기 성공 !"))
        }
    }

    void UnlockStage5(int onstage)
    {
        if (_dicAchievementUnlock[Achievements.Stage5])
            return;

        else if (onstage >= 5)
        {
            Debug.Log("스테이지5단계 클리어 !");
            _dicAchievementUnlock[Achievements.Stage5] = true;
        }
    }

    Text _achievementText;
    Text achievementText
    {
        get
        {
            if (_achievementText == null)
            {
                GameObject obj = GameObject.Find("Canvas/AchievementText");
                if (obj != null)
                {
                    _achievementText = obj.GetComponent<Text>();
                }
                
            }
            return _achievementText;
        }
        
    }

}
