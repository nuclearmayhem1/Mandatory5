using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EeeeMid : MonoBehaviour //PPart oof Marte's cup puzzle
{


    public GameObject E; //A worldspace UI button prompt
    public GameObject egg; //the item that gets "moved" in the cup puzzle, and must be watchhed and followed
    private bool withinRange; //Checks if player can press the button
    private Vector3 ESavedPos; //Where the button is
    private bool alreadyTriggered = false; //If the button has already been triggered



    
    void Start()
    {

        E.GetComponent<CanvasGroup>().alpha = 0;//Make button prompt transparent


        ESavedPos = E.transform.parent.transform.position; //Save where the button prompt is

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.transform.parent.transform.position = ESavedPos;
            E.GetComponent<CanvasGroup>().alpha = 1;

 
            withinRange = true; //If player is close to button, make it visible and pressable


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.GetComponent<CanvasGroup>().alpha = 0;

            withinRange = false; //If player is not close to button, make it transparent again


        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && withinRange && !alreadyTriggered)
        {
            E.GetComponent<CanvasGroup>().alpha = 0;
            alreadyTriggered = true;
            gameObject.GetComponent<Cups>().StartCupAnim();

            

            GetComponent<Animator>().enabled = true;

           Invoke("deleteEgg",2f);
           
           

        }
    }


    public void deleteEgg()
    {
        E.GetComponent<CanvasGroup>().alpha = 0;
        egg.SetActive(false);
        this.gameObject.SetActive(false);
    }



}
