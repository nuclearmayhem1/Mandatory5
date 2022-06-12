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
            //Move PushShroom back to start position 
            other.transform.position = LowerPuzzleThreeManager.Instance.PushShroomStart;
            
            //Reset its velocity to stop it's momentum
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
