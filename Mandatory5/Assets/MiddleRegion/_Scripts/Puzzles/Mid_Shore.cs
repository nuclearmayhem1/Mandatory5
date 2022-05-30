using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Shore : MonoBehaviour
{
    public bool reachedTheShore;
    public Mid_Boat midBoat;
    public List<GameObject> animalPlacements;
    public List<GameObject> animalsInBoat;
    public int i = 0;

    private void Start()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            midBoat = other.GetComponent<Mid_Boat>();
            midBoat.animal1.transform.parent = gameObject.transform;
            animalsInBoat.Add(midBoat.animal1);
            midBoat.animal2.transform.parent = gameObject.transform;
            animalsInBoat.Add(midBoat.animal2);
            FindNextAvailableSpot();
            midBoat.boatIsFull = false;
            midBoat.seatOneFilled = false;
        }
    }

    public void FindNextAvailableSpot()
    {
        animalsInBoat[1].transform.position = animalPlacements[i++].transform.position;
        Debug.Log("Animal was moved");

        animalsInBoat.RemoveAt(1);

        //foreach (GameObject animal in animalsInBoat)
        //{
        //    animal.transform.position = animalPlacements[i++].transform.position;
        //    Debug.Log("Animal was moved");
        //}

        //animalsInBoat.Clear();
    }
}
