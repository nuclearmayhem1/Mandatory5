using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Puz_3 : MonoBehaviour
{
    public string pickUpName;                       //Script is attached to the brush prefab, with their individual string name.

    private Mid_Puz_Door3 door3; 


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(true);
        door3 = GameObject.Find("Door").GetComponent<Mid_Puz_Door3>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {                                           //If the gameobject is in contact with the player, and has the matching string name
                                                    //- Set the following bool, in the scipt attached to the door, to be true.
            
            if(pickUpName == ("Brush1"))
            {
                door3.brushOne = true;
                
            }
            if (pickUpName == ("Brush2"))
            {
                door3.brushTwo = true;


                
            }
            if (pickUpName == ("Brush3"))
            {
                door3.brushThree = true;


            }
            gameObject.SetActive(false);                //Deactivate itself.
        }
    }

}
