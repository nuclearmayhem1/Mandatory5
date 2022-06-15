using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBridgeTrigger : MonoBehaviour
{
    //a script made to allow the last toggle shroom to activate the last bridge
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridge.SetActive(!bridge.activeSelf);
            
        }
    }
}
