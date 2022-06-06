using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MidBed : MonoBehaviour
{
    private bool withinRange, activated;
    public Material[] skyboxes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withinRange = false;
        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && withinRange && !activated)
        {
            Sleeb();
        }
    }


    private void Sleeb()
    {
        activated = true;
        GameObject.Find("Directional Light").GetComponent<Light>().color = new Color32(49, 44, 30, 1);
        
        RenderSettings.skybox = skyboxes[0];
    }
}
