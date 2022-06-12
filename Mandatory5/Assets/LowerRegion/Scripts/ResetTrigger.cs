using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    //Move certain objects back to start position upon touching this trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == LowerPuzzleThreeManager.Instance.PushShroom.name)
        {
            LowerPuzzleThreeManager.Instance.RespawnPushShroom();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = other.GetComponent<LowerRegionCheckpoint>().currentCheckpoint;
        }
    }
}
