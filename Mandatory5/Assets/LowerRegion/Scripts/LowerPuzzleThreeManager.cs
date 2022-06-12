using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPuzzleThreeManager : MonoBehaviour
{
    //Instance Variable for other scripts to reference to easily access this class
    public static LowerPuzzleThreeManager Instance;
    
    public GameObject PushShroom;
    [HideInInspector] public Vector3 PushShroomStart;

    private void Awake()
    {
        //Assigning Instance to this class
        Instance = this;
    }

    void Start()
    {
        if (PushShroom == null)
        {
            Debug.LogError("Please Assign PushShroom to Puzzle3Manager");
            return;
        }

        //Assign as the Spawn Position for Push Shroom
        PushShroomStart = PushShroom.transform.position;
    }
    
}
