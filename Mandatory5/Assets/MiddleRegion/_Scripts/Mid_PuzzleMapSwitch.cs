using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PuzzleMapSwitch : MonoBehaviour
{
    //private GameObject puzzleSpawnLocation;
    public GameObject firstPuzzleArea, secondPuzzleArea, thirdPuzzleArea, puzzleAreaDoor, closeTheDoorTrigger;

    private Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //puzzleSpawnLocation = GameObject.Find("PuzzleSpawnLocation");
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);
        //puzzleAreaDoor.SetActive(true);
        closeTheDoorTrigger.SetActive(false);
        doorAnimator = GameObject.Find("PuzzleDoor").GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnFirstPuzzle();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnSecondPuzzle();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnThirdPuzzle();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenPuzzleDoor();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ActivateDoorTrigger();
        }



    }


    public void SpawnFirstPuzzle()
    {
        firstPuzzleArea.SetActive(true);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);

    }
    public void SpawnSecondPuzzle() 
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(true);
        thirdPuzzleArea.SetActive(false);

    }
    public void SpawnThirdPuzzle() 
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(true);

    }

    public void OpenPuzzleDoor()
    {
        //puzzleAreaDoor.SetActive(false); // Open THe Door
        doorAnimator.SetBool("Open", true);

    }

    public void ActivateDoorTrigger()
    {
        closeTheDoorTrigger.SetActive(true);
    }
    


}
