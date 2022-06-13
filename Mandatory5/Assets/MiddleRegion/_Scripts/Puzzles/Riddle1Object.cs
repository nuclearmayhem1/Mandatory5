using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

public class Riddle1Object : MonoBehaviour
{
    private uint quest;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RiddleManager.Instance.RiddleSolved();
            QuestManager.SetNormalQuestStatus(0,true);
            gameObject.SetActive(false);
        }
    }
}
