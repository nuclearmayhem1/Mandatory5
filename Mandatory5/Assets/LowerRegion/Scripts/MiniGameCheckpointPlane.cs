using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckpointPlane : MonoBehaviour
{
   public Transform checkpointPos;
   private bool fightingTheMovement;

   private void OnTriggerEnter(Collider other) 
   {
       if(other.CompareTag("Player"))
       {
           ColorMiniGameController.cMGC.restartWholeGame = true;  
           ColorMiniGameController.cMGC.minigameHasEnded = true;    

           fightingTheMovement = true;
       }         
    }

    void LateUpdate()
    {
        if (Vector3.Distance(GameObject.Find("PlayerArmature").transform.position, checkpointPos.position) < 1f) fightingTheMovement = false;
        
        if (fightingTheMovement)
        {
            GameObject.Find("PlayerArmature").transform.position = checkpointPos.position;
        }
    }
}
