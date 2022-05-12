using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBridgeTrigger : MonoBehaviour
{
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridge.SetActive(!bridge.activeSelf);
            
        }
    }
}
