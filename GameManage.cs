using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  //Raycastを使うために
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    /*private GameObject SelectPanel;  //UI SelectPanel
    private GameObject FirstPanel;  //UI selectPanel
    private GameObject NextSelectPanel;  //UI NextSelectPanel
    public GameObject[] Towers;  // 4種類のタワー
    private GameObject SelectTower;　//選択されたタワー
    private Transform basePos;　　//　タワーのポジション */
    public static bool GameIsOver;
    public GameObject GameOverUI; //GAME OVER UI
    public GameObject buildEffect;     
    public PauseUI pauseUI;  
    
    
    
    

    
    
    void Start()
    {
        /*
        GameIsOver = false;
        SelectTower = null;
        SelectPanel = transform.Find("SelectCanvas").gameObject;　 //SelectPanelを見つける
        FirstPanel = SelectPanel.transform.GetChild(0).gameObject;　　//子のtransformを取得(FirstPanel)
        NextSelectPanel = SelectPanel.transform.GetChild(1).gameObject;　//子のtransformを取得(NextSelectPanel)*/
        
    }

    // Update is called once per frame
    void Update()
    {

       //1 if (Input.GetMouseButton(0))  //Mouseをクリックする
       //1 SelectBase();　//定義された方法

        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseUI.SwitchUI();
        }


        if (PlayerStatus.Lives <= 0)
        {
            GameEnd();
        }


    }


    /*private void SelectBase()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);　
        RaycastHit hit = new RaycastHit();　                           //Raycastによるマウス座標との当たり判定
        if(Physics.Raycast(ray ,out hit) && EventSystem.current.IsPointerOverGameObject( )==false)  //UI上のオブジェクトをいじってるときにはクリックを無視できる
        {
            if (hit.collider.gameObject.tag == "TowerBase")　　　　//tagはTowerBaseだだら
            {
                ShowSelectPanel(hit.transform);　　　　　　　　//ShowSelectPanelという方法
                basePos = hit.transform;           //タワーのポジションを取得

            }
        }
        // Debug.Log("hit=" + hit.collider.gameObject);

    }*/

    /*private void ShowSelectPanel(Transform pos)
    {
        SelectPanel.transform.SetParent(pos, false);
        SelectPanel.transform.localPosition = new Vector3(0, 15, 0);　　//SelectPanelのポジション
        SelectPanel.SetActive(true);　　//SelectPanelを表示する
    }*/

    /*private void ShowUpgradePanel(Transform pos)
    {
        UpgradePanel.transform.SetParent(pos, false);
        UpgradePanel.transform.localPosition = new Vector3(0, 30, 0);
        UpgradePanel.SetActive(true);
    }*/

   /* public void SelecttowerOne(bool isOn)  //bool型の選択
    {
        if (isOn)
        {
           // Debug.Log("SelecttowerOne");
            SelectTower = Towers[0];　　　　//選択されたタワー
            FirstPanel.SetActive(false);　　//FirstPanelを見えないように
            NextSelectPanel.SetActive(true); //NextSelectPanelを見えるように
            
        }
    }

    public void SelecttowerTwo(bool isOn)
    {
        if (isOn)
        {
           // Debug.Log("SelecttowerTwo");
            SelectTower = Towers[1];  //選択されたタワー
            FirstPanel.SetActive(false);  //FirstPanelを見えないように
            NextSelectPanel.SetActive(true);  //NextSelectPanelを見えるように
            
        }
    }

    public void SelecttowerThree(bool isOn)
    {
        if (isOn)
        {
            // Debug.Log("SelecttowerThree");
            SelectTower = Towers[2];  //選択されたタワー
            FirstPanel.SetActive(false);  //FirstPanelを見えないように
            NextSelectPanel.SetActive(true);  //NextSelectPanelを見えるように
           
        }
    }

    public void SelecttowerFour(bool isOn)
    {
        if (isOn)
        {
           //  Debug.Log("SelecttowerFour");
            SelectTower = Towers[3];  //選択されたタワー
            FirstPanel.SetActive(false);  //FirstPanelを見えないように
            NextSelectPanel.SetActive(true);  //NextSelectPanelを見えるように
            
        }
    }

    public void CloseAll()
    {
        SelectPanel.SetActive(false); //SelectCanvasを閉じる
        NextSelectPanel.SetActive(false);　　//NextSelectPanelを見えるように
        FirstPanel.SetActive(true);　　//FirstPanelを見えるように
    }

    public void CloseNext()
    {
        NextSelectPanel.SetActive(false);　//NextSelectPanelを見えるように
        FirstPanel.SetActive(true);　　　//FirstPanelを見えるように
    }

    public void CreatTower()　　//タワーを作る
    {
        // Debug.Log("作る");
        if(SelectTower != null)  //選択されたタワーがあれば
        {
            
            var costmoney = SelectTower.GetComponent<TowerPrice>().cost;
            //Debug.Log(costmoney);
            PlayerStatus.Coin -= costmoney;
            //Debug.Log(PlayerStatus.Coin);
            GameObject tempTower = Instantiate(SelectTower, basePos.position, Quaternion.identity);　　//オブジェクトを生成する関数
            tempTower.transform.SetParent(basePos, false);
            tempTower.transform.localPosition = new Vector3(0, 3, 0);  　//タワーが生成するポジション
            tempTower.AddComponent<TowerAI>();　　//TowerAIというスクリプトを利用する
            InItUI();　　//初期化の方法を使う
            GameObject buildEffect0 = Instantiate(buildEffect, basePos.position, Quaternion.identity);
            
            // Destroy(buildEffect0, 2f);
        }
       
    }

    public void SaleTower()　　//タワーを売る
    {
        
        var costmoney = SelectTower.GetComponent<TowerPrice>().cost;
        // Debug.Log("売る");
        if (basePos.childCount >=2)  //子のオブジェクトの数が2以上であれば
        {
            Destroy(basePos.GetChild(1).gameObject);　　//作ったタワーをクリア
            PlayerStatus.Coin += costmoney;
            InItUI();　　//初期化という方法
        }
        else
        {
            //Debug.Log("ターゲットポジションでタワーがない!");　//作ったタワーがない
        }
    }*/

    /*public void UpgradeTower()        
    {
        
        ShowUpgradePanel(transform);
        var upgradecostmoney = SelectTower.GetComponent<TowerPrice>().upgradecost;
        if (PlayerStatus.Coin < upgradecostmoney)
        {
            //Debug.Log("お金が足りない");
            return;
        }
        PlayerStatus.Coin -= upgradecostmoney;
        //Destroy(SelectTower);
       // GameObject tempTower = Instantiate(selectedTowerPrice.UpgradePrefab, basePos.position, Quaternion.identity);
        //tempTower.transform.SetParent(basePos, false);
       // tempTower.transform.localPosition = new Vector3(0, 8, 0);   
        //tempTower.AddComponent<TowerAI>();　　
    }
    */

    /*private void InItUI()　　//初期化という方法
    {
        SelectTower = null;　//選択されたタワーがない
        SelectPanel.SetActive(false);　　//SelectCanvasを表示しない
        FirstPanel.SetActive(true);　　//FirstPanelを表示する
        NextSelectPanel.SetActive(false);　　// NextSelectPanelを表示しない
    }*/
    private void GameEnd()
    {
        GameIsOver = true;
        //Debug.Log("GameOver");
        GameOverUI.SetActive(true);
    }
}
