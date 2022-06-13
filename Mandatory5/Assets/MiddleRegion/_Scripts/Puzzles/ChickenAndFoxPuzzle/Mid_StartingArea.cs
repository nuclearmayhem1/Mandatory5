using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_StartingArea : MonoBehaviour
{
    public List<GameObject> animalsInStartingArea, animalsToBeMoved, chickensInArea, foxesInArea;
    public List<Vector3> startingPositions;
    public List<GameObject> currentPositions;
    public Mid_Shore shoreScript;
    public bool endGame;

    public Mid_RestartFoxAndChicken restartScript;

    private void Start()
    {
        AddAnimals();
        restartScript = GameObject.Find("FoxAndChickenRestartCanvas").GetComponent<Mid_RestartFoxAndChicken>();
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
            endGame = true;
        }
        if (animalsToBeMoved.Count <= 5)
        {
            if (foxesInArea.Count > chickensInArea.Count)
            {
                restartScript.Lose();
            }
        }
    }

    public void AddAnimals()
    {
        foreach (GameObject animal in animalsInStartingArea)
        {
            startingPositions.Add(animal.transform.position);
            currentPositions.Add(animal);
        }
    }
}
