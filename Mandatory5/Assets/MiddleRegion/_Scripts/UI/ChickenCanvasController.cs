using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCanvasController : MonoBehaviour
{

    public GameObject initiateIcon, speechBubble, speechBubbleText, dialogueTrigger;
    public bool resetting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!initiateIcon)
        {
            initiateIcon = gameObject.transform.Find("SpeechIcon").gameObject; //searches within this gameobject for the icon
        }
        
        initiateIcon.SetActive(true); //enalbes it
    }

    public void StartTalking()
    {
        resetting = false;
        initiateIcon.SetActive(false);
        
        speechBubble.GetComponent<Animator>().SetBool("StartAnim", true); //starts the talking animation
        
        //speechBubble.SetActive(true);
    }

    public void resetSpeech()
    {
        
        if (!resetting)
        {
            initiateIcon.SetActive(true);
            resetting = true;
            Invoke("ExternalInvokeResetDialogue", 2f ); //Adds a delay to the reset, to allow for the animation to finish
        }

    }

    private void ExternalInvokeResetDialogue()
    {
        dialogueTrigger.GetComponent<ChickenDialogueTrigger>().ResetDialogue();
    }
}
