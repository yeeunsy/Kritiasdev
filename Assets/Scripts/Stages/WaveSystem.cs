using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSystem : MonoBehaviour
{
    //[SerializeField]
    //private GameObject enemyPrefab;
    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private EnemySpawner enemySpawner;
    private int currentWaveIndex = -1;
    //private Wave currentWave;

    /*private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        Instantiate(currentWave.enemyPrefabs[enemyIndex]);
    }*/

    public int CurrentWave => currentWaveIndex + 1; //시작 웨이브 포인트 = 0
    public int MaxWave => waves.Length;

    public void StartWave()
    {
        if ( enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length-1)
        {
            currentWaveIndex ++;
            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}