using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public float range =100;
    public string enemyTag = "Enemy";
    public Transform target;
    public Transform head;
    public float rotSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(" UpdateTarget", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        if (target == null) return;
        LockTarget();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color =Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
            if (minDistance < range)
            {
                target = nearestEnemy;
            }
            else
            {
                target = null;
            }
        }
    
    private void LockTarget()
        {
            Vector3 dir = target.position - transform.position;
            Debug.Log(head);
            Quaternion rotation=Quaternion.LookRotation(dir);
            Quaternion lerpRot =Quaternion.Lerp(head.rotation, rotation, Time.deltaTime*rotSpeed);           
            head.rotation = Quaternion.Euler(new Vector3(0, lerpRot.eulerAngles.y, 0));
        }
    }

