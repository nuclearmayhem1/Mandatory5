using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEN_Mid_VolcanoBorder : MonoBehaviour
{
    public Material[] skyboxes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.skybox = skyboxes[1];
        }
    }
}
