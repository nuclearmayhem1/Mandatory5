using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Boat : MonoBehaviour
{
    public Animator boatAnimator;
    public GameObject animal1, animal2;
    public Vector3 startPosition, endPosition1, endPosition2;
    public GameObject ghostAnimal1, ghostAnimal2, objectToMove;
    public bool boatIsFull;
    public bool seatOneFilled;
    public bool playerTouchedBoat;
    
  
    // Start is called before the first frame update
    void Start()
    {
        boatAnimator = gameObject.GetComponentInParent<Animator>();
        seatOneFilled = false;

        startPosition = transform.position;
        endPosition1 = ghostAnimal1.transform.position;
        endPosition2 = ghostAnimal2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (animal1 != null && animal2 != null)
        {
            boatIsFull = true;
        } else
        {
            boatIsFull = false;
        }
    }

    private void OnTriggerEnter(Collider other) //The issue is that all the if statements are true at the same time.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTouchedBoat = true;
        }


        /*if (other.gameObject.CompareTag("Fox") || other.gameObject.CompareTag("Chicken"))
        {
            if (seatOneFilled)
            {
                //other.gameObject.transform.SetParent(gameObject.transform);
      
                animal2 = other.gameObject;
                
            }
            if (!seatOneFilled)
            {
                //other.gameObject.transform.SetParent(gameObject.transform);
                animal1 = other.gameObject;
                Invoke("CanFill", 0.5f);
                
            }           
        }*/

    }

    public void MoveAnimalToBoat()
    {
        
        if (!seatOneFilled)
        {
            objectToMove.transform.position = endPosition1;
            objectToMove.transform.SetParent(gameObject.transform);

            animal1 = objectToMove.gameObject;
            Invoke("CanFill", 0.5f);
        }
           
        if (seatOneFilled)
        {
            objectToMove.transform.position = endPosition2;
            objectToMove.transform.SetParent(gameObject.transform);

            animal2 = objectToMove.gameObject;

        }
    }

    public void CanFill()
    {
        seatOneFilled = true; 
    }

    
}
