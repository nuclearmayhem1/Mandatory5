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

   
   public GameObject[] characters, /*The yellow bird is changed each riddle*/ spawnedObject; //If riddle needs an object spawned, this is it
   public GameObject riddleHintUI; // On-screen instructions to the riddle
   public String[] quests;
   public int currentRiddle = 0, currentRiddlemaster = 0; //What riddle we are on
   private void Awake() => Instance = this;


   private void Start()
   {
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
      /* riddleHintUI.GetComponent<TMP_Text>().text = "- " + hint;                //makes screen say the hint you wrote in the inspector
         riddleHintUI.GetComponent<TMP_Text>().color = new Color(1f, 1f, 1f, 1f); THIS CODE WAS REPLACED BY NEW QUEST SYSTEM */
      
      if (QuestManager.GetQuests(Quest.World.ChickRepublic).Length < currentRiddle+1) // Checks if the quest is already added
      {
         QuestManager.AddQuest(new Quest(Quest.World.ChickRepublic, quests[spawnObject])); //adds a new quest
         spawnedObject[spawnObject].SetActive(true);  //Set the hint and the object you want spawned in the inspector
      }
      
   }
   public void RiddleSolved() //Lets the player know they're done and changes to next bird
   {
      /*riddleHintUI.GetComponent<TMP_Text>().text = "Solved! Return to the riddlemaster.";
      riddleHintUI.GetComponent<TMP_Text>().color = Color.green; THIS CODE WAS REPLACED BY NEW QUEST SYSTEM*/
      SpawnCharacter(currentRiddlemaster+1);
      currentRiddle = currentRiddle+1;
   }   

}
