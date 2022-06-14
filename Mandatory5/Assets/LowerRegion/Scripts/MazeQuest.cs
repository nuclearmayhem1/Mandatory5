using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MazeQuest : MonoBehaviour
{
    private bool acceptedQuest = false, completedQuest = false;
    private uint mazeQuest = 1;

    private void Start()
    {
        QuestMenuRenderer.currentWorld = Quest.World.LowerWorld;
    }

    void Update()
    {
        if (GetComponent<MidDialogue>().dialogueNumber == 2 && acceptedQuest == false)
        {
            mazeQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Find the Shrooms in the small maze"));
            acceptedQuest = true;
        }

        if (MazeQuestCompletion.hasBeenCollected == true && completedQuest == false)
        {
            Debug.Log("TEST");
            QuestManager.SetNormalQuestStatus(1, true);
            completedQuest = true;
        }
    }
}
