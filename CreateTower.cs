using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour
{
    private GameObject SelectPanel;  //UI SelectPanel
    private GameObject FirstPanel;  //UI selectPanel
    private GameObject NextSelectPanel;  //UI NextSelectPanel
    private GameObject[] Towers;  // 4種類のタワー
    private GameObject SelectTower;　//選択されたタワー
    private Transform basePos;　　//　タワーのポジション
    private string selectTowerTag; //選択されたタワーのタグ
    private int tempIndex;
    private GameObject temp;
    


    void Start()
    {
        
        Towers = Resources.LoadAll<GameObject>("Prefabs/Towers");
        selectTowerTag = "Untagged";
        tempIndex = 0;
        SelectTower = null;
        SelectPanel = transform.Find("SelectCanvas").gameObject;　 //SelectPanelを見つける
        FirstPanel = SelectPanel.transform.GetChild(0).gameObject;　　//子のtransformを取得(FirstPanel)
        NextSelectPanel = SelectPanel.transform.GetChild(1).gameObject;　//子のtransformを取得(NextSelectPanel)
    }


    void Update()
    {
        if (Input.GetMouseButton(0))  //Mouseをクリックする
            SelectBase();　//定義された方法
        
    }


    private void ShowSelectPanel(Transform pos)
    {
        SelectPanel.transform.SetParent(pos, false);
        SelectPanel.transform.localPosition = new Vector3(0, 15, 0);　　//SelectPanelのポジション
        SelectPanel.SetActive(true);　　//SelectPanelを表示する
    }

    private void SelectBase()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();　                           //Raycastによるマウス座標との当たり判定
        if (Physics.Raycast(ray, out hit) && EventSystem.current.IsPointerOverGameObject() == false)  //UI上のオブジェクトをいじってるときにはクリックを無視できる
        {
            temp = null;
            if(hit.transform.tag=="TowerBase")
            {
                
                ShowSelectPanel(hit.transform);　　　　　　　　//ShowSelectPanelという方法
                basePos = hit.transform;           //タワーのポジションを取得  
                temp = hit.transform.gameObject;
                if (hit.transform.childCount ==2)
                {
                    NextSelectPanel.SetActive(true); 
                    FirstPanel.SetActive(false);
                }
            }

        }
    }

    private GameObject TargetTower(GameObject[] array, string name)
    {
        GameObject tempTower = null;
        foreach (var tower in array)
        {
            if (tower.name == name)
            {
                tempTower = tower;
            }
        }
        return tempTower;
    }

    private void InstantiateTower(GameObject towers, string tags)
    {
        GameObject tower = Instantiate(towers);
        //tower.transform.parent = temp.transform;
        tower.transform.SetParent(basePos, false);
        tower.transform.localPosition = new Vector3(0, 2.5f, 0);
        tower.transform.localRotation = Quaternion.identity;
        tower.transform.localScale = new Vector3(2, 2, 2);
        if (tower.GetComponent<TowerAI>() == null)
        {
            tower.AddComponent<TowerAI>();
        }
        tower.tag = tags;      
        tower.GetComponent<TowerAI>().upgradeIndex = tempIndex;
        tempIndex = 0;
        temp = null;
    }

    public void SelecttowerOne(bool isOn)  //bool型の選択
    {
        if (isOn)
        {

            // SelectTower = Towers[0];　　　　//選択されたタワー
            SelectTower = TargetTower(Towers, "Tow_BaseLaser");
            selectTowerTag = "D";
            FirstPanel.SetActive(false);　　//FirstPanelを見えないように
            NextSelectPanel.SetActive(true); //NextSelectPanelを見えるように

        }
    }



    public void SelecttowerTwo(bool isOn)
    {
        if (isOn)
        {

            //SelectTower = Towers[1];  //選択されたタワー
            SelectTower = TargetTower(Towers, "Tow_BaseCannon");
            selectTowerTag = "A";
            FirstPanel.SetActive(false);  //FirstPanelを見えないように
            NextSelectPanel.SetActive(true);  //NextSelectPanelを見えるように

        }
    }

    public void SelecttowerThree(bool isOn)
    {
        if (isOn)
        {

            //SelectTower = Towers[2];  //選択されたタワー
            SelectTower = TargetTower(Towers, "Tow_BaseMortar");
            selectTowerTag = "B";
            FirstPanel.SetActive(false);  //FirstPanelを見えないように
            NextSelectPanel.SetActive(true);  //NextSelectPanelを見えるように

        }
    }

    public void SelecttowerFour(bool isOn)
    {
        if (isOn)
        {

            //SelectTower = Towers[3];  //選択されたタワー
            SelectTower = TargetTower(Towers, "Tow_BaseGatling");
            selectTowerTag = "C";
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

    private void InItUI()　　//初期化という方法
    {
        SelectTower = null;　//選択されたタワーがない
        SelectPanel.SetActive(false);　　//SelectCanvasを表示しない
        FirstPanel.SetActive(true);　　//FirstPanelを表示する
        NextSelectPanel.SetActive(false);　　// NextSelectPanelを表示しない
    }

    public void CreatTower()　　//タワーを作る
    {

        if (SelectTower != null)  //選択されたタワーがあれば
        {

            var costmoney = SelectTower.GetComponent<TowerPrice>().cost;
            PlayerStatus.Coin -= costmoney;
            //GameObject tempTower = Instantiate(SelectTower, basePos.position, Quaternion.identity);　　//オブジェクトを生成する関数
            //tempTower.transform.SetParent(basePos, false);
            //tempTower.transform.localPosition = new Vector3(0, 2.5f, 0);  　//タワーが生成するポジション
            //tempTower.AddComponent<TowerAI>();　　//TowerAIというスクリプトを利用する 
            InstantiateTower(SelectTower, selectTowerTag);
            InItUI();  //初期化の方法を使う

        }

    }

    public void SaleTower()　　//タワーを売る
    {

        //var costmoney = SelectTower.GetComponent<TowerPrice>().cost;
        if (basePos.childCount >=2)  //子のオブジェクトの数が2以上であれば
        {
            Destroy(basePos.GetChild(1).gameObject);　　//作ったタワーをクリア
          // PlayerStatus.Coin += costmoney;
            InItUI();　　//初期化という方法
        }
        else
        {
            //Debug.Log("ターゲットポジションでタワーがない!");　//作ったタワーがない
        }
    }

    private GameObject InstantiateUpdateTower(string tag, int number)
    {
        GameObject tower = null;
        switch (tag)
        {
            case "A":
                if (1 == number)

                    tower = TargetTower(Towers, "Tow_UpgradeOneCannon");
                else
                    tower = TargetTower(Towers, "Tow_UpgradeTwoCannon");
                break;
            case "B":
                if (1 == number)

                    tower = TargetTower(Towers, "Tow_UpgradeOneMortar");
                else
                    tower = TargetTower(Towers, "Tow_UpgradeTwoMOrtar");
                break;
            case "C":
                if (1 == number)

                    tower = TargetTower(Towers, "Tow_UpgradeOneGatling");
                else
                    tower = TargetTower(Towers, "Tow_UpgradeTwoGatling");
                break;
            case "D":
                if (1 == number)

                    tower = TargetTower(Towers, "Tow_UpgradeOneLaser");
                else
                    tower = TargetTower(Towers, "Tow_UpgradeTwoLaser");
                break;
        }
        tower.tag = tag;
        return tower;
    }

    public void UpdateTower()
    {
        
            if (temp != null && temp.transform.childCount !=0 && temp.transform.GetChild(0).GetComponent<TowerAI>().upgradeIndex < 2)
            {
                temp.transform.GetChild(0).GetComponent<TowerAI>().upgradeIndex++;
                tempIndex = temp.transform.GetChild(0).GetComponent<TowerAI>().upgradeIndex;
                GameObject towers = InstantiateUpdateTower(temp.transform.GetChild(0).tag, tempIndex);
                Destroy(temp.transform.GetChild(0).gameObject);
                InstantiateTower(SelectTower, selectTowerTag);
                InItUI();  //初期化の方法を使う
            }
            else
            {
                Debug.Log("aaa");
            }
        
    }
}