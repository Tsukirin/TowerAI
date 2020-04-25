using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType　　　　
{
    NORMAL,                //enum typeを使う
    LASER,
}

 [RequireComponent(typeof(Rigidbody))]  　　  　//自動的にPhysicsコンポを組み合わせる
 [RequireComponent(typeof(SphereCollider))] 　 

public class TowerAI : MonoBehaviour
{   
    private TowerType type;            //タワーのタイプ
    public List<GameObject> enemy;    //攻撃できる敵の集合
    private GameObject targetObject;　　//目標オブジェクト
    //private float contrast;  //距離を比較する
    private Transform turret;　　//タワーの位置
    private float times;　　//時間を計る
    private GameObject bulletPrefab;　//弾のPrefab
    private Transform firePos;  //弾を打つポジション
    public int upgradeIndex;  //アップグレードのため
    private bool canAttack;
    private LineRenderer line;

   public TowerType GetTypes
    {
        set { type = value; }   　　//タワーについての種類の読み書き
        get { return type; }
    }


    void Start()
    {

        canAttack = false;
        times = 0;
       // contrast = 1000;
       // targetObject = null;
        enemy = new List<GameObject>();
        turret = transform.GetChild(0);
        firePos = turret.GetChild(0);
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet") ;　　　//弾のPrefabのルート
        GetComponent<SphereCollider>().isTrigger = true;
        GetComponent<SphereCollider>().radius = 10;
        GetComponent<Rigidbody>().useGravity = false;
        
    }

    
    void Update()
    {
        
        /* if(enemy.Count > 0)　　
         {
             if(targetObject == null)
             {
                 targetObject = SelectTarget();　　//敵を選択する状態
             }
         }
         if(targetObject != null)
         {
             LookTarget();　　//敵を狙う状態
         }*/
        if (canAttack)
        {
            times += Time.deltaTime;           
            Attack();
        }
        if (enemy.Count > 0 && targetObject != null)
        {
            LookTarget();
            
        }
        else
        {
            canAttack = false;
        }
        if (times >= 2)
        {
            TowerReflet();
            times = 0;
        } 
    } 

    public void OnTriggerEnter(Collider other) {                  //敵がタワーの攻撃の範囲に入る時
        if (other.tag == "Enemy"&& !enemy.Contains(other.gameObject))
        {
            //if (!enemy.Contains(other.gameObject))　　　　//敵がこの集合の中にかどうか
           // {
                enemy.Add(other.gameObject);
                canAttack = true;//そうじゃなければ、このオブジェクトを追加された
            //}
        }
    }

    public void OnTriggerExit(Collider other)　　　//敵がタワーの攻撃の範囲に外れるとき
    {
        if (other.tag == "Enemy")
        {
           // if (targetObject != null && other.name == targetObject.name)　//目標のオブジェクトがあるかつこの敵が目標の敵の場合
           // {
               
           // }
               // if (enemy.Contains(other.gameObject))　　//敵がこの集合の中にあれば
               // {
                enemy.Remove(other.gameObject);             //この敵のオブジェクトを削除する
           　　// }
        }
    }

   /* private GameObject SelectTarget()　　　　//敵を選択する
    {
        GameObject temp = null;
        float distance = 0;　　　//比較
        for (int i = 0;i < enemy.Count; i++)　　　//敵を並べ
        {
            contrast = Vector3.Distance(transform.position, enemy[i].transform.position);　　//自分と敵の距離
            
                if ( distance <= contrast)
                {
                    contrast = distance;
                    temp = enemy[i];        //一番近い敵を選択する

                }         
        

        return temp;
    }*/

    private void LookTarget()　　//敵を選択する状態
    {
        Vector3 pos= targetObject.transform.position;　//目標の位置
        pos.y = turret.position.y;　
        turret.LookAt(pos);　　//タワーは敵のポジションを狙う
       /* times += Time.deltaTime;
        if (times >= 1)
        {
            Attack();　　　//攻撃の状態
            
            times = 0;
        }*/
    }
    /* private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);　　　//オブジェクトを生成する
        bullet.AddComponent<BulletMove>().target =targetObject;　　　//弾の目標はこのオブジェクト
        bullet.transform.LookAt(targetObject.transform.position);　　//弾がこの目標を狙う
        bullet.GetComponent<BulletMove>().scripts = this;　　　//弾が移動するスクリプトはこれです
        
    }*/

    private void UpdateList()
    {
        List<int> temp = new List<int>();
        for(int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i] = null)
                temp.Add(i);
        }
        for(int j = 0; j < temp.Count; j++)
        {
            enemy.RemoveAt(temp[j]-j );
        }
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        //bullet.transform.localScale = new Vector3(2, 2, 2);
        if (bullet.GetComponent<BulletMove>() == null)
            bullet.AddComponent<BulletMove>();
        bullet.AddComponent<BulletMove>().target = targetObject;
    }

   /* private void CreateLaser()
    {
        line.enabled = true;
        line.startWidth = 0.1f;
        line.SetPosition(0, firePos.position);
        line.SetPosition(1, targetObject.transform.position + Vector3.up * 3);
        targetObject.GetComponent<EnemyHealth>().Damage(50);
        StartCoroutine(CloseLine());
    }

    private IEnumerable CloseLine()
    {
        yield return new WaitForSeconds(0.1f);
        line.enabled = false;
        StopCoroutine(CloseLine());
    }*/

    private void Attack()
    {
        if (enemy.Count > 0 && enemy[0] == null)
        {
            UpdateList();
        }
        if (enemy.Count > 0)
        {
            if (enemy[0] != null && enemy.Contains(enemy[0]))
            {
                targetObject = enemy[0];
                LookTarget();
            }
            else
            {
                UpdateList();
            }
        }
        else
        {
            canAttack = false;
        }
    }

    private void TowerReflet()
    {
       if (targetObject != null)
            
                CreateBullet();
                  
    }
}
