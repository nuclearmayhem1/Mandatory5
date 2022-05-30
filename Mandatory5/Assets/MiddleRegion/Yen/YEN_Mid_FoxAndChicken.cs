using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEN_Mid_FoxAndChicken : MonoBehaviour
{
    //public Vector3 startPosition, endPosition1, endPosition2;
    public GameObject ghostAnimal1, ghostAnimal2;
    public bool firstSeat, canPressE;
    public Mid_Boat boat;

    public void Start()
    {
        /*startPosition = transform.position;
        endPosition1 = ghostAnimal1.transform.position;
        endPosition2 = ghostAnimal2.transform.position;
        firstSeat = false; */


    }

    private void Update()
    {
        if (canPressE && boat.boatIsFull == false) 
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                boat.MoveAnimalToBoat();



            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPressE = true; 
            boat.objectToMove = this.gameObject;
            /*if (Input.GetKeyUp(KeyCode.E))
            {
                boat.MoveAnimalToBoat();


               /*if (!firstSeat)
                {
                    transform.position = endPosition1;
                    firstSeat = true;
                }
               if (firstSeat)
                {
                    transform.position = endPosition2;

                }
            }*/
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPressE = false;

    }
}
