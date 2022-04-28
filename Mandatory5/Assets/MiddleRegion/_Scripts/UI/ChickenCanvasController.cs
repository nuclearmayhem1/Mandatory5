using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCanvasController : MonoBehaviour
{

    public GameObject initiateIcon, speechBubble, speechBubbleText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!initiateIcon)
        {
            initiateIcon = gameObject.transform.Find("SpeechIcon").gameObject;
        }
    }

    public void StartTalking()
    {
        initiateIcon.SetActive(false);
        
        speechBubble.GetComponent<Animator>().SetBool("StartAnim", true);
        
        //speechBubble.SetActive(true);
    }
}
