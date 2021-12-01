using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab;    //타워 생성 프리팹
    public GameObject followTowerPrefab;  //임시 타워 프리팹
    public Weapon[] weapon;               //레벨별 타워 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite;   //보여지는  타워 이미지 (UI)
        public float damage;    //공격력
        public float slow;      //감속 퍼센트 (0.2 = 20%)
        public float buff;      //공격력증가율 (0.2 = 20%)
        public float rate;      //공격속도
        public float range;     //공격범위
        public int cost;        //필요 골드 
        public int sell;        //타워 판매
    }

}
