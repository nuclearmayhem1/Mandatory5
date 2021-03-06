using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

public class MidClawWin : MonoBehaviour
{
    private GameObject player;
    public GameObject clawMachineConsole, cannister, turnFOn;
    

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
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                
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
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            ClawWin();
        }
    }

    public void ClawWin()
    {
        turnFOn.SetActive(true);
        clawMachineConsole.gameObject.SetActive(false);
        QuestManager.SetNormalQuestStatus(RiddleManager.Instance.CurrentQuest,true);
        QuestManager.RemoveQuest(RiddleManager.Instance.CurrentQuest-3);
        RiddleManager.Instance.RiddleSolved();
        
        gameObject.SetActive(false);
        
        
    }
}
