using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonController))]
public class LowerRegionCheckpoint : MonoBehaviour
{
    //Instance Variable for other scripts to reference to easily access this class
    public static LowerRegionCheckpoint Instance;

    public Vector3 currentCheckpoint;
    private void Awake()
    {
        //Assigning Instance to this class
        Instance = this;
    }

    private void Start()
    {
        currentCheckpoint = transform.position;
    }
}
