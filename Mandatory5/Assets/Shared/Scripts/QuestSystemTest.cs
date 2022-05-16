using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class QuestSystemTest : MonoBehaviour
{
    public Quest.World world;
    public string title;

    public bool addQuest;
    public bool progressQuest;
    public bool removeQuest;

    private uint ID;

    void Update()
    {
        if (addQuest)
        {
            QuestMenuRenderer.currentWorld = world;
            addQuest = false;
            ID = QuestManager.AddQuest(new Quest(world, title));
        }

        if (progressQuest)
        {
            progressQuest = false;
            QuestManager.SetRadialQuestStatus(ID, QuestManager.GetRadialQuestStatus(ID) + 3);
            QuestManager.SetNormalQuestStatus(ID, true);
        }

        if (removeQuest)
        {
            removeQuest = false;
            QuestManager.RemoveQuest(ID);
        }
    }
}
