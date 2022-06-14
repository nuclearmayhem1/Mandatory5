using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EeeeMid : MonoBehaviour
{

    public GameObject E; //A UI button
    private bool withinRange; //Checks if player can press button
    private Vector3 ESavedPos; //Where the button is


    // Start is called before the first frame update
    void Start()
    {
        E.GetComponent<CanvasGroup>().alpha = 0; //Make button transparent

        ESavedPos = E.transform.parent.transform.position; //Save where the button is
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.transform.parent.transform.position = ESavedPos;
            E.GetComponent<CanvasGroup>().alpha = 1;
            withinRange = true;
            //If player is close to button, make it visible and pressable

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.GetComponent<CanvasGroup>().alpha = 0;
            withinRange = false;
            //If player is not close to button, make it transparent again

        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && withinRange)
        {
            gameObject.GetComponent<Cups>().StartCupAnim();



            GetComponent<Animator>().enabled = true;

           

        }
    }





}
