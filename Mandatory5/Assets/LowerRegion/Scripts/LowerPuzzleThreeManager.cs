using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LowerPuzzleThreeManager : MonoBehaviour
{
    //Instance Variable for other scripts to reference to easily access this class
    public static LowerPuzzleThreeManager Instance;
    
    public GameObject PushShroom;
    private Vector3 PushShroomStart;
    

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

        //Assign as the Spawn Position for Push Shroom with an offset on 1 unit on the y axis
        PushShroomStart = PushShroom.transform.position + Vector3.up;
    }

    private void Update()
    {
        if (PushShroom.transform.position.y < -4)
        {
            //Respawn PushShroom when y coord is under the map
            RespawnPushShroom();
        }
    }

    public void RespawnPushShroom()
    {
        //Move PushShroom back to start position 
        PushShroom.transform.position = PushShroomStart;
        //Reset its velocity to stop it's momentum
        PushShroom.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    
}
