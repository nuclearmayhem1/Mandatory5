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
        boatAnimator = gameObject.GetComponent<Animator>();
        seatOneFilled = false;

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        endPosition1 = ghostAnimal1.transform.position;
        endPosition2 = ghostAnimal2.transform.position;

        if (animal1 != null && animal2 != null)
        {
            boatIsFull = true;
        } else
        {
            boatIsFull = false;
        }

        if (animal1 != null)
        {
            animal1.transform.position = endPosition1;
        }
        if (animal2 != null)
        {
            animal2.transform.position = endPosition2;
        }
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

    public void ClearAnimalsInBoat()
    {
        GameObject.Find("Shore").GetComponent<Mid_Shore>().animalsInBoat.Clear();
    }
}
