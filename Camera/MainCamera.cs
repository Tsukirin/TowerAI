using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float moveSpeed = 80f;
    public float ScrollSpeed = 100f;
      
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed *Time.deltaTime;
        }         
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.position += Vector3.up*scroll * ScrollSpeed * Time.deltaTime*20;
        }
       
    }
}
