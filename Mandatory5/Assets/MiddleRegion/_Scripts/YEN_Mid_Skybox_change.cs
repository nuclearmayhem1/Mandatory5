using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEN_Mid_Skybox_change : MonoBehaviour
{

    
    public Material[] skyboxes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("PLayer entered the Volcano level");
            RenderSettings.skybox = skyboxes[1];
        }
    }

    

    // Start is called before the first frame update

}
