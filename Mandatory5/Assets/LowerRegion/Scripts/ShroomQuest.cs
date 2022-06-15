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
        QuestMenuRenderer.currentWorld = Quest.World.LowerWorld;
    }

    void Update()
    {
        if (dialogue.GetComponent<MidDialogue>().dialogueNumber == 4 && acceptedQuest == false)
        {
            shroomQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Get the golden mushroom on the top of the mountain"));
            Destroy(gate1);
            Destroy(gate2);
            acceptedQuest = true;
        }
    }
}