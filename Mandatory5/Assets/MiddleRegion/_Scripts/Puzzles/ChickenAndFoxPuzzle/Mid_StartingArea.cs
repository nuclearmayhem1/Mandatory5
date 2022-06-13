using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_StartingArea : MonoBehaviour
{
    public List<GameObject> animalsInStartingArea, animalsToBeMoved;
    public List<Vector3> startingPositions;
    public List<GameObject> currentPositions;
    public bool endGame;

    private void Start()
    {
        foreach (GameObject animal in animalsInStartingArea)
        {
            startingPositions.Add(animal.transform.position);
            currentPositions.Add(animal);
        }
    }
    private void Update()
    {
        for (int i = 0; i < animalsInStartingArea.Count; i++)
        {
            if (currentPositions[i].transform.position != startingPositions[i])
            {
                animalsInStartingArea[i].GetComponent<Mid_FoxAndChicken>().hasBeenMoved = true;
            }
        }

        if (animalsToBeMoved.Count == 0)
        {
            Debug.Log("All animals are gone");
            endGame = true;
        }
    }
}
