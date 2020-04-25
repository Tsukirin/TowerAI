using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject target ;
    public TowerAI scripts = null;
    private Vector3 targetPos;
    public float damage = 50;
    
    
    public GameObject GetTarget
    {
         set { target = null; }
         get { return target; }
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        Attack();
        
              
    }
    private void Attack()
    {
        if (target != null)
        {
            /*if (Vector3.Distance(transform.position, target.transform.position) < 40f)
             {

                 EnemyDamage();              
                 Destroy(gameObject);              
                 EnemySpawner.EnemyAlive--;
                 scripts.enemy.Remove(target);          
             }*/
            targetPos = target.transform.position + Vector3.up * 3;
            transform.LookAt(targetPos);
            if (Vector3.Distance(transform.position, targetPos) >0.5f)
            {

                transform.Translate(Vector3.forward * Time.deltaTime * 100);
                
            }

            else
            {
                Destroy(gameObject);
                EnemyDamage();
            }
        }
    }

    private void EnemyDamage()
    {
        EnemyHealth enemyHp = target.GetComponent<EnemyHealth>();
        if( enemyHp != null)
        {
            enemyHp.Damage(damage);
        }
    }
}
