using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathpoints : MonoBehaviour
{
    public static Transform[] pathPoints;      　　　　　//Transformというタイプの配列を宣言する
    private void Awake()
    {
        pathPoints = new Transform[transform.childCount];　　//子オブジェクトを取得する
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i] = transform.GetChild(i);　　　　　
        }
    }
 
}
