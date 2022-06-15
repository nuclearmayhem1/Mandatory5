using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PuzzleIDea_Kev : MonoBehaviour
{
    
    //For the volcano stone puzzle.
    //The stones that are not the correct path have triggers. Meaning that the player falls through the gameobject.
    

    private void OnTriggerEnter(Collider other)                     
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<MeshRenderer>().enabled = false;          //When the player falls through a rock;
                                                                        //the Mesh Renderer on the rock is disabled. 
        }
    }

}
