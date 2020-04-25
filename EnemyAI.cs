using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 50;
    Transform target;
    private int pointIndex = 0;  
    void Start()
    {
        target = Pathpoints.pathPoints[pointIndex];       
    }
  
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.forward = dir.normalized;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position, transform.position) < 1f)
        {

            pointIndex++;
            //終点に到達した
            if (pointIndex >= Pathpoints.pathPoints.Length)
            {
                PathEnd();
                return;
            }
            target = Pathpoints.pathPoints[pointIndex];
        }
    }
    private void PathEnd()
    {
        PlayerStatus.Lives--;
        EnemySpawner.EnemyAlive--;
        Destroy(gameObject);
    }
}
