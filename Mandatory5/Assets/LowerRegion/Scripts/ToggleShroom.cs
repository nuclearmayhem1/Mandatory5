using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShroom : MonoBehaviour
{
    public GameObject sporeZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sporeZone.SetActive(!sporeZone.activeSelf);
        }
    }

}