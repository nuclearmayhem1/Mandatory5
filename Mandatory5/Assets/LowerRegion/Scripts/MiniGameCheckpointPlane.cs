using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckpointPlane : MonoBehaviour
{
   public Transform checkpointPos;
   private bool fightingTheMovement;
   private GameObject player;

   private void OnTriggerEnter(Collider other) 
   {
       if(other.CompareTag("Player"))
       {
           ColorMiniGameController.cMGC.restartWholeGame = true;  
           ColorMiniGameController.cMGC.minigameHasEnded = true;
           player = other.gameObject;

           fightingTheMovement = true;
       }         
    }

    void LateUpdate()
    {
        if(player)
        if (Vector3.Distance(player.transform.position, checkpointPos.position) < 1f) fightingTheMovement = false;
        
        if (fightingTheMovement)
        {
            player.transform.position = checkpointPos.position;
        }
    }
}
