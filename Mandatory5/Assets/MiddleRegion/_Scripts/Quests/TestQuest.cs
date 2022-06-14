using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TestQuest : MonoBehaviour
{
    private uint quest = 0; //The quest IDs are just numbers based on which were added first, 0 being the first.

    void Start()
    {
        QuestMenuRenderer.currentWorld = Quest.World.ChickRepublic;

        QuestManager.AddQuest(new Quest(Quest.World.ChickRepublic, "Find a rock", 3));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            QuestManager.SetRadialQuestStatus(quest, QuestManager.GetRadialQuestStatus(quest) + 1);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuestManager.RemoveQuest(quest);
        }
    }
}
