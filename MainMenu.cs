using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButtonClick()
    {
        sceneFader.FadeOut("Game");
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
