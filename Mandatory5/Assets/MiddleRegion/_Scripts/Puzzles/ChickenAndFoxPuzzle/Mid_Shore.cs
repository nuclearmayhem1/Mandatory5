using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mid_Shore : MonoBehaviour
{
    public bool reachedTheShore;
    public Mid_Boat midBoat;
    public List<GameObject> foxPlacements, chickenPlacements;
    public List<GameObject> animalsInBoat;
    public int f = 0, c = 0;
    public int foxesOnShore, chickensOnShore;
    public int chosenAnimal = 0;
    public Mid_ChooseAnimalToSendOver chooseAnimal;

    public Mid_RestartFoxAndChicken restartScript;

    private void Start()
    {
        restartScript = GameObject.Find("FoxAndChickenRestartCanvas").GetComponent<Mid_RestartFoxAndChicken>();
        midBoat = GameObject.Find("Boat_Mobile").GetComponent<Mid_Boat>();
        chooseAnimal = GameObject.Find("FoxAndChickenCanvas").GetComponent<Mid_ChooseAnimalToSendOver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            BoatArrived();
        }
    }

    public void BoatArrived()
    {
        animalsInBoat.Add(midBoat.animal1);
        animalsInBoat.Add(midBoat.animal2);
        chooseAnimal.OpenCanvas();
        Invoke("FindNextAvailableSpot", 0.1f);
        midBoat.objectToMove = null;
    }

    public void FindNextAvailableSpot()
    {
        if (chosenAnimal == 0)
        {
            midBoat.animal1.transform.parent = null;
            midBoat.animal1.SetActive(false);
            midBoat.animal1 = null;

        } else if (chosenAnimal == 1)
        {
            midBoat.animal2.transform.parent = null;
            midBoat.animal2.SetActive(false);
            midBoat.animal2 = null;
        }

        if (animalsInBoat[chosenAnimal].gameObject.CompareTag("Fox"))
        {
            //animalsInBoat[chosenAnimal].transform.position = foxPlacements[f].transform.position;
            foxPlacements[f++].transform.GetChild(0).gameObject.SetActive(true);
            foxesOnShore += 1;
        }
        else if (animalsInBoat[chosenAnimal].gameObject.CompareTag("Chicken"))
        {
            //animalsInBoat[chosenAnimal].transform.position = chickenPlacements[c].transform.position;
            chickenPlacements[c++].transform.GetChild(0).gameObject.SetActive(true);
            chickensOnShore += 1;
        }

        animalsInBoat.RemoveAt(chosenAnimal);

        if (foxesOnShore + chickensOnShore >= 2 && foxesOnShore + chickensOnShore != 6 && chickensOnShore >= 1)
        {
            if (foxesOnShore > chickensOnShore)
            {
                restartScript.Lose();
            }
        }

        if (foxesOnShore + chickensOnShore == 6)
        {
            restartScript.Win();
        }
    }
}
