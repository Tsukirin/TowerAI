using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public SceneFader sceneFader;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButtonClick()
    {
        SwitchUI();
    }

    public void RetryButtonClick()
    {
        SwitchUI();
        sceneFader.FadeOut(SceneManager.GetActiveScene().name);
    }

    public void MenuButtonClick()
    {
        SwitchUI();
        sceneFader.FadeOut("MainMenu");
    }

    public void SwitchUI()
    {
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
