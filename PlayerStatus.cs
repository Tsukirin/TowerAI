using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int StartCoin = 10;
    public static int Coin;
    public List<GameObject> Towers;
    private Text targetText;
    public int StartLives = 3;
    public static int Lives;
    public static int Rounds; //敵のwaveを表示する

    
    
    // Start is called before the first frame update
    void Start()
    {
        Coin = StartCoin;
        Lives = StartLives;
        Rounds = 0;
        Towers = new List<GameObject>();
        this.targetText = this.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        //this.targetText.text = Coin.ToString();
        
    }
}
