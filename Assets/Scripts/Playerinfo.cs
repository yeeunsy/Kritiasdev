using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item")]
public class Playerinfo : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public int quantity;
    public bool stackable;
    public enum ItemType
    {
        COIN,
        EXP
    }
    public ItemType itemType;
}

    //{
    /*public GameObject towerPrefab;    //타워 생성 프리팹
    public GameObject followTowerPrefab;  //임시 타워 프리팹
    public Weapon[] weapon;*/               //레벨별 타워 정보

    /*[System.Serializable]
    public struct Profile
    {
        public Sprite sprite;   //보여지는 플레이어 프로파일 (UI)
        public float damage;    //경험치
        public int cost;        //소지 골드
        public int sell;        //소지 타워 갯수
    }*/
    //}