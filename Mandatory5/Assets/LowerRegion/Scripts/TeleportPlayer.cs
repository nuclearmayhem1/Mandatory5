using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TeleportPlayer : MonoBehaviour
{
    public Transform checkpointPos;
    private bool fightingTheMovement, acceptedQuest;
    private GameObject player;
    private uint minigameQuest = 2;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (acceptedQuest == false && RunningShroom.shroomGameQuestCompleted == false)
            {
                minigameQuest = QuestManager.AddQuest(new Quest(Quest.World.LowerWorld, "Complete the Shroom minigames"));
                acceptedQuest = true;
            }
            fightingTheMovement = true;
            player = other.gameObject;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            if (Vector3.Distance(player.transform.position, checkpointPos.position) < 1f) fightingTheMovement = false;
        }
        
        if (fightingTheMovement)
        {
            player.transform.position = checkpointPos.position;
        }
        
        if (acceptedQuest == true && RunningShroom.shroomGameQuestCompleted == true)
        {
            QuestManager.SetNormalQuestStatus(minigameQuest, true);
        }
    }
}
