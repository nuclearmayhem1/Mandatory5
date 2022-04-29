using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGameManager : MonoBehaviour
{
    
    
    
    // void Awake()
    // {
    //     //GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
    //
    //     // if (objs.Length > 1)
    //     // {
    //     //     Destroy(this.gameObject);
    //     // }
    //
    //     DontDestroyOnLoad(this.gameObject);
    // }
    
    private static GameObject instance;
    void Start() 
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
