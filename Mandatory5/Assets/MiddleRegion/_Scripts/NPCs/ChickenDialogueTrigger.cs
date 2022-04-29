using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDialogueTrigger : MonoBehaviour
{
    [HideInInspector]public bool dialogueAlreadyStarted = false;
    private GameObject chickenCanvas;
    private GameObject speechBubbleText;
    
    private void Start()
    {
        chickenCanvas = gameObject.transform.parent.transform.Find("ChickenCanvas").gameObject;

        speechBubbleText = chickenCanvas.GetComponent<ChickenCanvasController>().speechBubbleText;
        
        if (!chickenCanvas)
        {
            Debug.LogError("Can't find the chicken canvas bro, maybe the person who made this script should've just made it a public variable and assigned it manually lol");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueAlreadyStarted)
        {
            
            if (speechBubbleText.activeSelf)
            {
                //Find the speech bubble text
                speechBubbleText.gameObject.GetComponent<MidDialogue>().NextDialogue(); 
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !dialogueAlreadyStarted)
        {
            
            //Debug.Log("Initialized Dialogue");

            dialogueAlreadyStarted = true;
            //Invoke("AllowStartingDialogueAgain",2f);

            chickenCanvas.GetComponent<ChickenCanvasController>().StartTalking();

        }
    }
}
