using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEN_Mid_VolcanoBorder : MonoBehaviour
{
    public Material[] skyboxes;
    public Light volcanoLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.skybox = skyboxes[1];
            volcanoLight.color = new Color(0.4716981f, 0.1005946f, 0.05191641f);
        }
    }
}
