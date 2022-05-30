using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Shore : MonoBehaviour
{
    public bool reachedTheShore;
    public Mid_Boat midBoat;
    public List<Transform> animalPlacements;
    public Vector3 availableSpot;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            FindNextAvailableSpot();
            midBoat = other.GetComponent<Mid_Boat>();
            midBoat.animal1.transform.parent = gameObject.transform;
            midBoat.animal1.transform.position = availableSpot;
            //Invoke("FindNextAvailableSpot", 3f);
            //Debug.Log("Next available spot was executed with delay");
            midBoat.animal2.transform.parent = gameObject.transform;
            midBoat.animal2.transform.position = availableSpot;
        }
    }

    public void FindNextAvailableSpot()
    {
        Debug.Log("Next available spot was executed");
        for (int i = 0; i < animalPlacements.Count; i++)
        {
            Debug.Log("Ran once");
            return;
        }
    }
}
