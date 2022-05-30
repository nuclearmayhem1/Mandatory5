using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_SetBoatOff : MonoBehaviour
{

    public bool canPressE;
    public Mid_Boat midBoat;
    public Animator boatAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPressE && canPressE == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                midBoat.MoveAnimalToBoat();
            }
        }

        if (midBoat.seatOneFilled == true && midBoat.playerTouchedBoat)
        {
            boatAnim.SetBool("Two animals", true);
            if (Input.GetKeyDown(KeyCode.L))
            {
                boatAnim.SetBool("Two animals", true);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                boatAnim.SetBool("Two animals", false);
            }
        }


    
        
        
    }
    

    }

