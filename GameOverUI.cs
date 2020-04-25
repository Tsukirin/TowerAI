using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;
    private void OnEnable()
    {
        StartCoroutine(ShowRoundsText());
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RetryButton()
    {
        //Debug.Log("Retry");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        sceneFader.FadeOut(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        //Debug.Log("Menu");
        sceneFader.FadeOut("Mainmenu");
    }
    IEnumerator ShowRoundsText()
    {
        int rounds = 0;
        roundsText.text = rounds.ToString();
        yield return new WaitForSeconds(0.5f);

        while (rounds < PlayerStatus.Rounds)
        {
            rounds++;
            roundsText.text = rounds.ToString();
            yield return new WaitForSeconds(0.06f);
        }

    }
}
