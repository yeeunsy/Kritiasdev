using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   //적 프리팹 public GameObject respawnPrefab;
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    //[SerializeField]
    //private float spawnTime;        //적 생성 주기
    [SerializeField]
    private StageManager stageManager;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private PlayerExp playerExp;
    [SerializeField]
    private PlayerGold playerGold;
    private Wave currentWave;
    private int currentEnemyCount;
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList;

    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;
    public int spawnEnemyCount = 0; //현 웨이브 적수

    private void Awake()
    {
        enemyList = new List<Enemy>(); //적 정보 불러오기

        //StartCoroutine("SpawnEnemy");
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;   //현재 웨이브
        currentEnemyCount = currentWave.maxEnemyCount;  //현재 적 
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;

        //while (true)
        //현재 웨이브에서 생성되어야 하는 적의 숫자만큼 적을 생성하고 코루틴 종료
        while ( spawnEnemyCount < currentWave.maxEnemyCount )
        {
            //GameObject clone = Instantiate(enemyPrefab); //적 오브젝트 생성
            // 웨이브에 등장하는 적의 종류가 여러 종류일 때 임의의 적이 등장하도록 설정, 적 오브젝트 생성
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(this, wayPoints);
            enemyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            spawnEnemyCount ++;

            yield return new WaitForSeconds(currentWave.spawnTime);
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int gold, int exp)
    {
        if ( type == EnemyDestroyType.Arrive )
        {
            playerHP.TakeDamage(1);
            //stageCondition.TakeCount(1);
        }

        else if ( type == EnemyDestroyType.Kill )
        {
            playerGold.CurrentGold += gold;
            playerExp.CurrentExp += exp;
            //stageCondition.TakeCount(1);
        }
        stageManager.TakeCount(1);

        currentEnemyCount --;

        enemyList.Remove(enemy);

        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }

}

