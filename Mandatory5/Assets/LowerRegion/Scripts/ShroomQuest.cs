using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class ShroomQuest : MonoBehaviour
{
    private bool acceptedQuest = false, completedQuest = false;
    private uint shroomQuest = 0;
    public GameObject dialogue, gate1, gate2;

    private void Start()
    {
        QuestMenuRenderer.currentWorld = Quest.World.LowerWorld;            //Sets the current region in the questmanager.
    }

    void Update()
    {
        if (dialogue.GetComponent<MidDialogue>().dialogueNumber == 4 && acceptedQuest == false)  //Checks for dialogue line then give quests and flip bool to not make it repeat
        {                                          
            shroomQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Get the golden mushroom on the top of the mountain"));
            Destroy(gate1);
            Destroy(gate2);             //Destroys gates to let player in, forcing them to pick up this quest.
            acceptedQuest = true;
        }

        if (acceptedQuest == true && ShroomQuestCompletion.shroomQuestObjectiveComplete == true) //Gets quest objective completion from ShroomQuestCompletion.cs and sets quests as complete.
        {
            QuestManager.SetNormalQuestStatus(shroomQuest, true);
        }
    }
}