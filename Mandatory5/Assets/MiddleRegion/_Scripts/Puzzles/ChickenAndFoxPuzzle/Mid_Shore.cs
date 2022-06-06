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
    public int chosenAnimal = 0;
    public Mid_ChooseAnimalToSendOver chooseAnimal;

    private void Start()
    {
        chooseAnimal = GameObject.Find("FoxAndChickenCanvas").GetComponent<Mid_ChooseAnimalToSendOver>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            animalsInBoat.Add(midBoat.animal1);
            animalsInBoat.Add(midBoat.animal2);
            Debug.Log(animalsInBoat.Count);
            midBoat = other.GetComponent<Mid_Boat>();
            chooseAnimal.OpenCanvas();
            Invoke("FindNextAvailableSpot", 1f);
            //midBoat.boatIsFull = false;
        }
    }

    public void FindNextAvailableSpot()
    {
        Debug.Log(chosenAnimal + " is the chosen animal dumbass");

        if (chosenAnimal == 0)
        {
            midBoat.animal1.transform.parent = gameObject.transform;
            midBoat.animal1 = null;

        } else if (chosenAnimal == 1)
        {
            midBoat.animal2.transform.parent = gameObject.transform;
            midBoat.animal2 = null;

        }
        animalsInBoat[chosenAnimal].transform.position = animalPlacements[i++].transform.position;
        animalsInBoat.RemoveAt(chosenAnimal);

        //foreach (GameObject animal in animalsInBoat)
        //{
        //    animal.transform.position = animalPlacements[i++].transform.position;
        //    Debug.Log("Animal was moved");
        //}

        //animalsInBoat.Clear();
    }
}
