using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public AnimationCurve curve;
    public Image blackImg;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
             float a =curve.Evaluate(t);
            blackImg.color = new Color(0, 0, 0, a);
            yield return null;
        }
        
    }

    public void FadeOut(string name)
    {
        StartCoroutine(FadeOutByTime(name));
    }


    IEnumerator FadeOutByTime(string name)
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            blackImg.color = new Color(0, 0, 0, a);
            yield return null;
        }
        SceneManager.LoadScene(name);
    }
    }
