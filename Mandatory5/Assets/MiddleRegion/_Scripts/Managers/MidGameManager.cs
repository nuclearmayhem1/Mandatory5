using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGameManager : MonoBehaviour
{
    public GameObject puzzlePiece1, puzzlePiece2, puzzlePiece3;
    public bool piece1Collected, piece2Collected, piece3Collected, allPiecesCollected;


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

    public void PuzzlePiecesStart()
    {
        puzzlePiece1 = GameObject.Find("PuzzlePiece1");
        puzzlePiece2 = GameObject.Find("PuzzlePiece2");
        puzzlePiece3 = GameObject.Find("PuzzlePiece3");
    }
    public void PuzzlePiecesCollected()
    {
        if (piece1Collected == true && piece2Collected == true && piece3Collected == true)
        {
            allPiecesCollected = true;
        }
    }
}
