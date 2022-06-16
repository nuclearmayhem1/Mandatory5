using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeZone : MonoBehaviour
{
    Vector3 startScale;
    private bool standardScaleSet = false;
    private bool newScaleSet = false;
    private float elapsedTime = 0;
    public GameObject mazeCam;

    private void OnTriggerEnter(Collider other)     //Checks for player, saves its current scale and flips a bool to confirm it.
    {
        if(other.CompareTag("Player"))
        startScale = other.transform.localScale;
        standardScaleSet = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elapsedTime += Time.deltaTime;          //Waits one second to make sure the standardscale gets to set.
            if (elapsedTime > 1f)
            {
                if (standardScaleSet == true && newScaleSet == false)
                {
                    other.transform.localScale = new Vector3(other.transform.localScale.x * 0.1f, other.transform.localScale.y * 0.1f,
                        other.transform.localScale.z * 0.1f);

                    newScaleSet = true;
                    mazeCam.SetActive(true);        //Sets new small scale and activates the maze camera.
                                                    //Flips a bool to make sure it only happens once.
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (standardScaleSet == true && newScaleSet == true)    //Reverses back to the original saved scale when exiting.
            {
                other.transform.localScale = startScale;
                standardScaleSet = false;
                newScaleSet = false;
                elapsedTime = 0f;
            }
            mazeCam.SetActive(false);                               //Disables camera when exiting.
        }
    }
}
