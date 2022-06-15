using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

public class MidClawWin : MonoBehaviour
{
    private GameObject player;
    public GameObject clawMachineConsole;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            clawMachineConsole.GetComponent<ClawMachineConsole>().ResetToPlayer();
            other.transform.parent = other.transform;
            other.transform.eulerAngles = new Vector3(0, 0, 0);
            other.transform.position = new Vector3(player.transform.position.x+1, player.transform.position.y,
                player.transform.position.z);
                
            ClawWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            clawMachineConsole.GetComponent<ClawMachineConsole>().ResetToPlayer();
            other.transform.parent = other.transform;
            other.transform.eulerAngles = new Vector3(0, 0, 0);
            other.transform.position = new Vector3(player.transform.position.x+1, player.transform.position.y,
                player.transform.position.z);
            
            ClawWin();
        }
    }

    private void ClawWin()
    {
        QuestManager.SetNormalQuestStatus(5,true);
        RiddleManager.Instance.RiddleSolved();
        QuestManager.SetNormalQuestStatus(5,true);
        QuestManager.RemoveQuest(2);
        gameObject.SetActive(false);
        
        
    }
}
