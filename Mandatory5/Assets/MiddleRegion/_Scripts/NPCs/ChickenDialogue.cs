using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDialogue : MonoBehaviour
{
    private bool dialogueAlreadyStarted = false;
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !dialogueAlreadyStarted)
        {
            
            Debug.Log("Initialized Dialogue");

            dialogueAlreadyStarted = true;
            //Invoke("AllowStartingDialogueAgain",2f);

            gameObject.transform.parent.transform.Find("ChickenCanvas").GetComponent<ChickenCanvasController>().StartTalking();

        }
    }



    public void AllowStartingDialogueAgain()
    {
        dialogueAlreadyStarted = false;
        
    }
}
