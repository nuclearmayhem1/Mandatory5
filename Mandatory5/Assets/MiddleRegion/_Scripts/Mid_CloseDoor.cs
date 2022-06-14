using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_CloseDoor : MonoBehaviour
{ //Script is applied to a trigger that is positioned so that when the player goes back to the main area, the door will close.
    public GameObject puzzleAreaDoor;
    private Animator doorAnimator;
    private AudioSource audioSource;

    private void Start()
    {
        doorAnimator = GameObject.Find("PuzzleDoor").GetComponent<Animator>();
        audioSource = GameObject.Find("PuzzleDoor").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)                         //This will close the door.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //puzzleAreaDoor.SetActive(true); // Close the Door
            //doorAnimator.SetBool("Open", false);
            //audioSource.Play();
            
        }
    }

    private void OnTriggerExit(Collider other)                             //This is disable the trigger this script is attached to.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //this.gameObject.SetActive(false);

        }


    }
}
