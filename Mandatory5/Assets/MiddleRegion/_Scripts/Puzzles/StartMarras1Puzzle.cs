using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class StartMarras1Puzzle : MonoBehaviour
{
    public GameObject marrasCamera, firstCanvas;
    private GameObject player;
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.E))
        {
            player = GameObject.FindWithTag("Player");
            
            firstCanvas.SetActive(true);
            gameObject.SetActive(false);
            
            marrasCamera.SetActive(true);
            
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            player.GetComponent<ThirdPersonController>().LockCameraPosition = true;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            
        }
        
        
    }
}
