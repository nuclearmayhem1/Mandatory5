using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;
using UnityEngine.UIElements;

public class MazeQuestCompletion : MonoBehaviour
{
    public static bool hasBeenCollected = false;
    public GameObject mazeExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasBeenCollected = true;
            Destroy(mazeExit, 1f);
            Destroy(gameObject,1f); 
            Destroy(mazeExit.GetComponent<BoxCollider>());
        }
    }

    void Update()
    {
        if (hasBeenCollected == true)
        {
            mazeExit.transform.position = new Vector3(mazeExit.transform.position.x, mazeExit.transform.position.y - 1 * Time.deltaTime,
                mazeExit.transform.position.z);
        }
    }
}
