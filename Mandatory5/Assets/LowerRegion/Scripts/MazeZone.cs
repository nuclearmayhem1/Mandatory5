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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player ENTER");
        startScale = other.transform.localScale;
        standardScaleSet = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player STAY");
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1f)
            {
                if (standardScaleSet == true && newScaleSet == false)
                {
                    other.transform.localScale = new Vector3(other.transform.localScale.x * 0.1f, other.transform.localScale.y * 0.1f,
                        other.transform.localScale.z * 0.1f);

                    newScaleSet = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player EXIT");
            if (standardScaleSet == true && newScaleSet == true)
            {
                other.transform.localScale = startScale;
                standardScaleSet = false;
                newScaleSet = false;
                elapsedTime = 0f;
            }
        }
    }
}
