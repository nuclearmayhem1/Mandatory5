using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TestQuest : MonoBehaviour
{
    private uint quest;

    void Start()
    {
        QuestMenuRenderer.currentWorld = Quest.World.ChickRepublic;

        quest = QuestManager.AddQuest(new Quest(Quest.World.OverWorld, "Find a rock"));
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
