using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_CloseDoor : MonoBehaviour
{
    public GameObject puzzleAreaDoor;


   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            puzzleAreaDoor.SetActive(true);
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
