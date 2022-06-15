using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;
using UnityEngine.UIElements;

public class MazeQuestCompletion : MonoBehaviour
{
    public static bool hasBeenCollected = false;        //Makes the quest objective bool accessible to other scripts.
    public GameObject mazeExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))                 //Flips quest objective completion bool, sets a timer to destroy the exit,
                                                        //Destroys the quest objective itself to make it seem like you collect it.
        {
            hasBeenCollected = true;
            Destroy(mazeExit, 1f);
            Destroy(gameObject,1f); 
            Destroy(mazeExit.GetComponent<BoxCollider>());
        }
    }

    void Update()
    {
        if (hasBeenCollected == true)                   //Makes the door move down before destruction when the bool for objective completion is flipped.
        {
            mazeExit.transform.position = new Vector3(mazeExit.transform.position.x, mazeExit.transform.position.y - 1 * Time.deltaTime,
                mazeExit.transform.position.z);
        }
    }
}
