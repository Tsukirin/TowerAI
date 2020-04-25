using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    private GameObject selectedTurret;
    
    public GameObject SelectedTurret
    {
        get
        {
            return selectedTurret;
        }
        set
        {
            selectedTurret = value;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
