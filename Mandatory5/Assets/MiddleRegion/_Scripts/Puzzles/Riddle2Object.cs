using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

public class Riddle2Object : MonoBehaviour
{
    private uint quest;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            QuestManager.SetNormalQuestStatus(RiddleManager.Instance.CurrentQuest,true);
            RiddleManager.Instance.RiddleSolved();
            
            gameObject.SetActive(false);
        }
    }
}