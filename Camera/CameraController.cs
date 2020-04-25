using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject SubCamera;

    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        SubCamera = GameObject.Find("Sub Camera");
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            MainCamera.SetActive(false);
            SubCamera.SetActive(true);         
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            MainCamera.SetActive(true);
            SubCamera.SetActive(false);
        }
    }
}
