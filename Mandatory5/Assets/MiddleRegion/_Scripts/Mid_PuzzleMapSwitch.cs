using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PuzzleMapSwitch : MonoBehaviour
{
    //private GameObject puzzleSpawnLocation;
    public GameObject firstPuzzleArea, secondPuzzleArea, thirdPuzzleArea, puzzleAreaDoor, closeTheDoorTrigger;
    public GameObject fourthPuzzleAre, fifthPuzzleArea;

    public static Mid_PuzzleMapSwitch Instance;
    
    private Animator doorAnimator;
    private AudioSource audioSource;

    private void Awake() => Instance = this;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //puzzleSpawnLocation = GameObject.Find("PuzzleSpawnLocation");
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);
        fourthPuzzleAre.SetActive(false);
        fifthPuzzleArea.SetActive(false);
        //puzzleAreaDoor.SetActive(true);
        closeTheDoorTrigger.SetActive(false);
        doorAnimator = GameObject.Find("PuzzleDoor").GetComponent<Animator>();
        audioSource = GameObject.Find("PuzzleDoor").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        /*                                              //FOR TESTING!
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
        */
        

    }


    public void SpawnFirstPuzzle()                      //Call this method when getting the FIRST quest from the chicken. This will enable the puzzle area.
    {
        firstPuzzleArea.SetActive(true);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);
        fourthPuzzleAre.SetActive(false);
        fifthPuzzleArea.SetActive(false);

    }
    public void SpawnSecondPuzzle()                     //Call this method when getting the SECOND quest from the chicken. This will enable the puzzle area.
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(true);
        thirdPuzzleArea.SetActive(false);
        fourthPuzzleAre.SetActive(false);
        fifthPuzzleArea.SetActive(false);

    }
    public void SpawnThirdPuzzle()                      //Call this method when getting the THIRD quest from the chicken. This will enable the puzzle area.
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(true);
        fourthPuzzleAre.SetActive(false);
        fifthPuzzleArea.SetActive(false);

    }

    public void SpawnFourthPuzzle()                      //Call this method when getting the FOURTH quest from the chicken. This will enable the puzzle area.
                                                         //Comment out this section if there is no fourth and fifth puzzle area. 
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);
        fourthPuzzleAre.SetActive(true);
        fifthPuzzleArea.SetActive(false);
    }

    public void SpawnFifthPuzzle()                      //Call this method when getting the FIFTH quest from the chicken. This will enable the puzzle area.
                                                        //Comment out this section if there is no fifth puzzle area. 
    {
        firstPuzzleArea.SetActive(false);
        secondPuzzleArea.SetActive(false);
        thirdPuzzleArea.SetActive(false);
        fourthPuzzleAre.SetActive(false);
        fifthPuzzleArea.SetActive(true);
    }

    public void OpenPuzzleDoor()                                    //Call this method when getting the quest from the chicken.
                                                                    //This will open the puzzle area door.
    {
        //puzzleAreaDoor.SetActive(false); // Open THe Door
        doorAnimator.SetBool("Open", true);
        audioSource.Play();

    }

    public void ActivateDoorTrigger()                   //Call this method when the quest is complete.
                                                        //This will close the door when exiting the puzzle area.
    {
        closeTheDoorTrigger.SetActive(true);
    }
    


}
