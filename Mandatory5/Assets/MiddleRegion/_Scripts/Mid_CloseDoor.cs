using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_CloseDoor : MonoBehaviour
{
    public GameObject puzzleAreaDoor;
    private Animator doorAnimator;

    private void Start()
    {
        doorAnimator = GameObject.Find("PuzzleDoor").GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //puzzleAreaDoor.SetActive(true); // Close the Door
            doorAnimator.SetBool("Open", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);

        }


    }
}
