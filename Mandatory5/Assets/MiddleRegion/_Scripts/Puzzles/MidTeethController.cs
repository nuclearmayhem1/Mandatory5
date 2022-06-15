using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidTeethController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //END OF THE FIRST PART OF THIS PUZZLE HERE
        Debug.Log("WELL DONE");
        
        QuestManager.SetNormalQuestStatus(6,true);
        RiddleManager.Instance.RiddleSolved();
        QuestManager.SetNormalQuestStatus(6,true);
        QuestManager.RemoveQuest(3);
        GameObject.FindWithTag("Player").SetActive(true);
    }
}
