using System.Collections;
using System.Collections.Generic;
using Quests;
using StarterAssets;
using UnityEngine;

public class ChooseCup : MonoBehaviour
{
    public GameObject E, egg;
    private bool withinRange;
    private bool readyToChoose;
    public int cupNumber;
    private GameObject player;
    private bool won = false;
    
    // Start is called before the first frame update
    void Start()
    {
        E.GetComponent<CanvasGroup>().alpha = 0;
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && readyToChoose)
        {
            E.GetComponent<CanvasGroup>().alpha = 1;
            withinRange = true;

            E.transform.parent.transform.position = new Vector3(gameObject.transform.position.x, E.transform.parent.transform.position.y, gameObject.transform.position.z);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.GetComponent<CanvasGroup>().alpha = 0;
            withinRange = false;

        }
    }

  


    private void Update()
    {


        if (gameObject.transform.parent.transform.parent.GetComponent<MidJeff>().bedge)
        {
            readyToChoose = true;
        }

        if (Input.GetKey(KeyCode.E) && withinRange && readyToChoose)
        {
            
            gameObject.transform.parent.transform.parent.GetComponent<Animator>().SetBool("Reveal", true);

            eggCheck();
            

        }





    }


    private void eggCheck()
    {
        egg.SetActive(true);
        egg.GetComponent<Egg>().TeleportToCorrectCup();
        
        Debug.Log("the cup number is " + cupNumber + ", and the correct answer is " + egg.GetComponent<Egg>().posNumber);

        if (egg.GetComponent<Egg>().posNumber == cupNumber)
        {
            if (!won)
            {
                won = true;
                transform.parent.transform.parent.GetComponent<MidJeff>().correct = true;
            
                Debug.Log("YOU WINNED ");
                
                Debug.Log("Solved Marte's cup puzzle");
                
                QuestManager.SetNormalQuestStatus(RiddleManager.Instance.CurrentQuest,true);
                QuestManager.RemoveQuest(RiddleManager.Instance.CurrentQuest-3);
                RiddleManager.Instance.RiddleSolved();
                
            }
            

        }
        else
        {

            transform.parent.transform.parent.GetComponent<MidJeff>().correct = false;
            
            Time.timeScale = 1;
            
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
            // player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            // player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
            // player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            // player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
            // gameObject.GetComponent<CanvasGroup>().alpha = 0;
            // gameObject.GetComponent<CanvasGroup>().interactable = false;
            // gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
            RiddleManager.Instance.FailPuzzle();
        }
        


    }


}
