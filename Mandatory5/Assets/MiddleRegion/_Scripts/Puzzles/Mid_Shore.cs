using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Shore : MonoBehaviour
{
    public bool reachedTheShore;
    public Mid_Boat midBoat;
    public List<Vector3> animalPlacements;
    public List<GameObject> animalsInBoat;
    public int i;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            FindNextAvailableSpot();
            midBoat = other.GetComponent<Mid_Boat>();
            midBoat.animal1.transform.parent = gameObject.transform;
            animalsInBoat.Add(midBoat.animal1);
            //Invoke("FindNextAvailableSpot", 3f);
            //Debug.Log("Next available spot was executed with delay");
            midBoat.animal2.transform.parent = gameObject.transform;
            animalsInBoat.Add(midBoat.animal2);
        }
    }

    public void FindNextAvailableSpot()
    {
        Debug.Log("Next available spot was executed");
        foreach (GameObject animal in animalsInBoat)
        {
            animal.transform.position = animalPlacements[i++];
        }
        for (i = 0; i < animalPlacements.Count; i++)
        {

        }
    }
}
