using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RiddleManager : MonoBehaviour
{
   public static RiddleManager Instance;

   public GameObject prefabToSpawn, spawnedPrefab;
   
   public GameObject[] characters, /*The yellow bird is changed each riddle*/ spawnedObject; //If riddle needs an object spawned, this is it
   //public GameObject riddleHintUI; // On-screen instructions to the riddle (obsolete)
   public String[] quests;
   public int currentRiddle = 0, currentRiddlemaster = 0; //What riddle we are on
   private void Awake() => Instance = this;


   private void Start()
   {
      // foreach (GameObject i in spawnedObject)
      // {
      //    i.SetActive(false);
      // }
      foreach (GameObject i in characters)
      {
         i.SetActive(false);
      }
      
      characters[0].SetActive(true);
      
      QuestMenuRenderer.currentWorld = Quest.World.ChickRepublic;
      currentRiddle = 0;
      currentRiddlemaster = 0;
   }

   // Every riddle should be its own void in the manager
   public void SpawnCharacter(int chararcterNumber) //Changes out the bird. Each bird has their own riddle.
   {
      characters[chararcterNumber].SetActive(true);
      characters[chararcterNumber-1].SetActive(false);
   }

   public void StartNextRiddle(/*string hint,*/ int spawnObject) //Starts the first riddle
   {
      Debug.Log("Starting new riddle, current riddle" + currentRiddle);
      Debug.Log("Starting new riddle,current master: " +currentRiddlemaster);
      /* riddleHintUI.GetComponent<TMP_Text>().text = "- " + hint;                //makes screen say the hint you wrote in the inspector
         riddleHintUI.GetComponent<TMP_Text>().color = new Color(1f, 1f, 1f, 1f); THIS CODE WAS REPLACED BY NEW QUEST SYSTEM */
      
      if (QuestManager.GetQuests(Quest.World.ChickRepublic).Length < currentRiddle + 1) // Checks if the quest is already added
      {
         QuestManager.AddQuest(new Quest(Quest.World.ChickRepublic, quests[spawnObject])); //adds a new quest

         if (currentRiddle > 0)
         {
            Destroy(spawnedPrefab);
         }
         
         if (currentRiddle != 8)
         {
            prefabToSpawn = spawnedObject[currentRiddle];
            GameObject newGameObject = Instantiate(prefabToSpawn);
            spawnedPrefab = newGameObject;
            //spawnedObject[spawnObject].SetActive(true);  //Set the hint and the object you want spawned in the inspector
         } 
        else if (currentRiddle == 8)
        {
            LastPuzzle();
        }
      }


      
      // switch (spawnObject)
      // {
      //    case 3:
      //       Mid_PuzzleMapSwitch.Instance.SpawnFirstPuzzleArea();
      //       break;
      //    case 4:
      //       Mid_PuzzleMapSwitch.Instance.SpawnSecondPuzzleArea();
      //       break;
      //    case 5:
      //       Mid_PuzzleMapSwitch.Instance.SpawnThirdPuzzleArea();
      //       break;
      //    case 6:
      //       Mid_PuzzleMapSwitch.Instance.SpawnFourthPuzzleArea();
      //       break;
      //    case 7:
      //       Mid_PuzzleMapSwitch.Instance.SpawnFifthPuzzleArea();
      //       break;
      //    default:
      //       break;
      // }

      if (spawnObject > 2)
      {
         Mid_PuzzleMapSwitch.Instance.OpenPuzzleDoor();
         Mid_PuzzleMapSwitch.Instance.ActivateDoorTrigger();
      }
      
   }
   public void RiddleSolved() //Lets the player know they're done and changes to next bird
   {
      /*riddleHintUI.GetComponent<TMP_Text>().text = "Solved! Return to the riddlemaster.";
      riddleHintUI.GetComponent<TMP_Text>().color = Color.green; THIS CODE WAS REPLACED BY NEW QUEST SYSTEM*/

      if (currentRiddle == 1)
      {
         QuestManager.SetNormalQuestStatus(1,true);
      }
      
      
      if (currentRiddle > 3)
      {
         Mid_PuzzleMapSwitch.Instance.OpenPuzzleDoor();
      }
      
      SpawnCharacter(currentRiddlemaster+1);
      currentRiddle = currentRiddle+1;
      currentRiddlemaster = currentRiddlemaster + 1;
      Debug.Log("current riddle" + currentRiddle);
      Debug.Log("current master: " +currentRiddlemaster);
      
   }

    public void LastPuzzle()
    {
        GameObject.Find("Mid_PaintDispenser").GetComponent<Mid_PaintDispenser>().buttonsUnlocked = true;
    }

   public void FailPuzzle()
   {
      LateFail();
   }

   private void LateFail()
   {
      Time.timeScale = 1f;
      Destroy(spawnedPrefab);
      
      GameObject.FindWithTag("Player").GetComponent<MidPlayerController>().Respawn();

      //GameObject puzzlePrefab = new GameObject("Puzzle " + currentRiddle);
      //Vector3 objectPOS = Vector3.zero;
      
      prefabToSpawn = spawnedObject[currentRiddle];
      
      Invoke("SuperLateSpawn",0.1f); 
   }


   private void SuperLateSpawn()
   {
      GameObject newGameObject = Instantiate(prefabToSpawn);
      newGameObject.transform.parent = newGameObject.transform.parent;
      spawnedPrefab = newGameObject;
   }
}
