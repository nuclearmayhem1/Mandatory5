using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MazeQuest : MonoBehaviour
{
    private bool acceptedQuest = false, completedQuest = false;
    private uint mazeQuest = 1;
    public GameObject dialogue, mazeZone, Mushroom;
    public string[] completedDialogue;

    private void Start()
    {
        QuestMenuRenderer.currentWorld = Quest.World.LowerWorld; //Sets the current region for the quest manager.
    }

    void Update()
    {
        if (dialogue.GetComponent<MidDialogue>().dialogueNumber == 2 && acceptedQuest == false) //Checks what current line the dialogue is and
                                                                                                //runs the code if it is the first time.
        {
            mazeQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Find the Shrooms in the small maze"));
            acceptedQuest = true;   //Gives the quest, activates the maze the quest takes place in,
                                    //and flips a bool so it doesn't ever run again.
            mazeZone.SetActive(true);
        }

        if (MazeQuestCompletion.hasBeenCollected == true && completedQuest == false)    //Runs if quest objective is complete.
        {
            QuestManager.SetNormalQuestStatus(mazeQuest, true);                     //Sets the quest as completed.
            completedQuest = true;                                                      //Flips a bool to make it only run once.
            Mushroom.GetComponent<Animation>().Play("Attack");                  //Changes the questgiver's animation to now be "dancing".
            dialogue.GetComponent<MidDialogue>()._dialogue = completedDialogue;         //Updates the questgiver's dialogue.
        }
    }
}
