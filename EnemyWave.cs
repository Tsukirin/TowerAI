using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]　　//Inspectorの画面に表示される
public class EnemyWave {
    public GameObject enemyPrefab;  
    public int count;  //敵の数
    public float rate;　//敵のスピード
}

