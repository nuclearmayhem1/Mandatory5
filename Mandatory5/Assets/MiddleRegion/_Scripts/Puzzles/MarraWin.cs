using System.Collections;
using System.Collections.Generic;
using Quests;
using StarterAssets;
using UnityEngine;

public class MarraWin : MonoBehaviour
{
    private GameObject player;

    public GameObject MidTeethController, cameraToRemove;
    // Start is called before the first frame update
    void Start()
    {
        player = MidTeethController.GetComponent<MidTeethController>().player;
        
        Invoke("Win",5f);
    }

    private void Win()
    {
        cameraToRemove.SetActive(false);
        
        player.SetActive(true);
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        QuestManager.SetNormalQuestStatus(6,true);
        RiddleManager.Instance.RiddleSolved();
        QuestManager.SetNormalQuestStatus(6,true);
        QuestManager.RemoveQuest(4);
        GameObject.FindWithTag("Player").GetComponent<MidPlayerController>().Respawn();
    }
}
