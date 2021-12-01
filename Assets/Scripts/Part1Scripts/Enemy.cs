using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive, TutoEnemy }

public class Enemy : MonoBehaviour
{
    private int wayPointCount; //이동경로 개수 
    private Transform[] wayPoints; // 이동 경로 정보
    private int currentIndex = 0;  // 현재 목표지점 인덱스 출발지점
    private Movement2D movement2D; //오브젝트 이동 제어
    private EnemySpawner enemySpawner;  
    private Animator anim;
    //private int EnemyCount = 0; 
    //private int Exp

    //[SerializeField]
    private int gold = 10;
    //[SerializeField]
    private int exp = 30;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;
        // 적 이동 경로 WayPoints 정보 설정 
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove() //움직이고 있으면 실행
    {
        while (true) //연속적으로 움직임
        {
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.1f * movement2D.MoveSpeed) //웨이포인트의 길이를 비교하여 현재 객체의 속도 X 0.1이 남은거리보다 적다면
            {
                if (currentIndex < wayPointCount - 1) //0이 웨이포인트 개수보다 작으면
                {
                    transform.position = wayPoints[currentIndex].position; //내위치는 웨이포인트의 0번째의 인덱스
                    currentIndex++; //내인덱스 개수증가
                    Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized; //방향은 웨이포인트 의 위치 - 내위치의 정규화
                    if(direction[0] == 1){
                        right();
                    }else if(direction[0] == -1){
                        
                        left();
                    }else if(direction[1]== 1){
                        
                        up();
                    }else if(direction[1]== -1){
                        
                        down();
                    }
                }else
                {   gold = 5;
                    exp = 15;
                    //Destroy(gameObject);
                    OnDie(EnemyDestroyType.Arrive);

                }   
            }
            yield return null;
        }
    }

    private string up() //꺽을시 발생되는 이벤트 
    {  anim.SetTrigger("Up");
       movement2D.MoveTo(Vector3.up); //방향을 꺽는다
       return "Up";
    }
    private string down() //꺽을시 발생되는 이벤트 
    {  
       anim.SetTrigger("Down");
       movement2D.MoveTo(Vector3.down); //방향을 꺽는다
       return "Down";
    }
    private string left() //꺽을시 발생되는 이벤트 
    {   
        anim.SetTrigger("Left");
        movement2D.MoveTo(Vector3.left); //방향을 꺽는다
        return "Left";
    }
    private string right() //꺽을시 발생되는 이벤트 
    {   
        anim.SetTrigger("Right");
       movement2D.MoveTo(Vector3.right); //방향을 꺽는다
       return "Right";
    }

    public void OnDie(EnemyDestroyType type)
    {
        enemySpawner.DestroyEnemy(type, this, gold, exp);
    }
}