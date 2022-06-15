using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidTeethController : MonoBehaviour
{
    public GameObject player;
    public GameObject camera, canvasToRemove, marraPuzzle2;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Finish"))
        {
            //END OF THE FIRST PART OF THIS PUZZLE HERE
                    Debug.Log("WELL DONE");
                    canvasToRemove.SetActive(false);
                    //camera.SetActive(false);
                    // player.SetActive(true);
                    // player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
                    // player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
                    // player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
                    // player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
                        
                    other.gameObject.SetActive(false);
                    
                    marraPuzzle2.SetActive(true);
                    
                    // Cursor.visible = false;
                    // Cursor.lockState = CursorLockMode.Locked;
                    //
                    // QuestManager.SetNormalQuestStatus(6,true);
                    // RiddleManager.Instance.RiddleSolved();
                    // QuestManager.SetNormalQuestStatus(6,true);
                    // QuestManager.RemoveQuest(3);
        }
        
        
        
       
    }
}
