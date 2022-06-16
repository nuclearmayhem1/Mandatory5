using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{
    public Transform targetPosition, targetPosition2;
    public Vector3 targetPoint;
    public float moveSpeed = 1, waitTime;
    public float elapsedTime, stoppingDistance = 0.1f;
    private bool hasWaited = true;

    void Start()
    {
        targetPoint = targetPosition.position; //Makes the current destination easily viewable in Unity editor.
    }
    
    void OnTriggerEnter(Collider Other)
    {   
        if(Other.CompareTag("Player") || Other.CompareTag("PushShroom")) //Checks for Player and Pushroom and then parents 
        {                                                                //them under this object so they can inherit transforms.  
            if (Other.GetComponent<Rigidbody>())
            {
                Other.GetComponent<Rigidbody>().useGravity = false;
                Other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            Other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if(Other.CompareTag("Player") || Other.CompareTag("PushShroom"))    //When Player and Pushroom leaves they are now parentless.
        {
            if (Other.GetComponent<Rigidbody>())
                Other.GetComponent<Rigidbody>().useGravity = true;

            Other.transform.SetParent(null);
        }
    }


    void Update()
    {
        if(PlayerDrugChecker.isHigh == true) //Activates code if Player is under spore conditions.
        {
            if (hasWaited == true)  //Sets and moves platform if it doesn't need to wait.
            {
                Vector3 direction = targetPoint - transform.position;
                transform.Translate(direction.normalized * Time.deltaTime * moveSpeed);   
            }

            if (Vector3.Distance(transform.position, targetPosition2.position) < stoppingDistance) //Sets new target position.
            {
                hasWaited = false;              //Makes the platform have to wait
                elapsedTime += Time.deltaTime;  //Waits however long you set the time in Unity editor.
                if (elapsedTime > waitTime)
                {
                    targetPoint = targetPosition.position;
                    elapsedTime = 0;
                    hasWaited = true;
                }
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < stoppingDistance) //Sets and moves to second position, otherwise same as above.
            {
                hasWaited = false;
                elapsedTime += Time.deltaTime;
                if (elapsedTime > waitTime)
                {
                    targetPoint = targetPosition2.position;
                    elapsedTime = 0;
                    hasWaited = true;
                }
            }
        }
    }
}
