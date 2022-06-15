using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class PushShroomQuest : MonoBehaviour
{
    public GameObject dialogue;
    private bool acceptedQuest;
    private uint pushshroomQuest = 5;
    
    void Update()
    {
        if (dialogue.GetComponent<MidDialogue>().dialogueNumber == 2 && acceptedQuest == false)
        {
            pushshroomQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Push the shroom over the mountain"));
            acceptedQuest = true;
        }
        
        if(acceptedQuest == true && PuzzleThreeGateOpener.pushShroomQuestCompletion == true)
        {
            QuestManager.SetNormalQuestStatus(pushshroomQuest, true);
        }
    }
}
