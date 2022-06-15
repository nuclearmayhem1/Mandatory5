using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class ToggleShroomQuest : MonoBehaviour
{
    //this script gives the player a quest to cross the bog after they talk with the funguy.
    private bool acceptedQuest;
    public GameObject dialogue;
    private uint toggleShroomQuest = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.GetComponent<MidDialogue>().dialogueNumber == 4 && acceptedQuest == false) 
        {
            toggleShroomQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Find a way to cross the bog"));
            acceptedQuest = true;
        }

        if (acceptedQuest && ToggleShroomQuestCompletion.bogCrossed)
        {
            QuestManager.SetNormalQuestStatus(toggleShroomQuest, true);
        }
    }
}
