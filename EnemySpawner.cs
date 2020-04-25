using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static int EnemyAlive;　　　　//生きる敵
    public EnemyWave[] waveEnemy;　　　 //敵の種類、何回の繰り返す、移動する速さ
    public Transform spawnPoint;　　　　//始めるポジション
    public float spawnInterval = 1f;　　　//毎回敵間のインタバル
    private float countDown;　　　　//時計
    public Text timerText;　
    public int waveNum = 1;　//毎波敵数
    private int waveIndex;　//今は何回になる
    
    void Start()       
    { 
        countDown = spawnInterval;
        EnemyAlive = 0;
    }

    
    void Update()
    {
        if (GameManage.GameIsOver)
        {
            EnemyAlive = 0;
            return;
        }
       if(EnemyAlive > 0)
        {
            return;
        }

        if(waveIndex == waveEnemy.Length)
        {
            Debug.Log("Win");
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
        string time = string.Format("{0:00.00}", countDown);
        timerText.text = time;
        if (countDown <= 0)
        {
            countDown = spawnInterval;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        StartCoroutine(WaveEnemy());
    }

    IEnumerator WaveEnemy()
    {
        if (waveIndex >= waveEnemy.Length)
        {
            yield break;
        }
        //Roundsの数
        PlayerStatus.Rounds++; //敵のWaveを増加すること


        EnemyWave wave = waveEnemy[waveIndex];　　//今回の敵のデータ
        EnemyAlive = wave.count;　　　//生きる敵の数

        for (int i =0; i <wave.count; i++)
        {
            Instantiate(wave.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;
    }
}

