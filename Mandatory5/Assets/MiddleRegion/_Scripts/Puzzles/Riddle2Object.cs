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
            QuestManager.SetNormalQuestStatus(1,true);
            RiddleManager.Instance.RiddleSolved();
            QuestManager.SetNormalQuestStatus(1,true);
            gameObject.SetActive(false);
        }
    }
}