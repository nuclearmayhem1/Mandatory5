using System.Collections;
using Quests;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Mid_RestartFoxAndChicken : MonoBehaviour
{
    public Text text;
    private bool alreadyStarted = false;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        text = GetComponentInChildren<Text>();
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void Win()
    {
        
        // gameObject.GetComponent<CanvasGroup>().alpha = 1;
        // gameObject.GetComponent<CanvasGroup>().interactable = true;
        // gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        text.text = "You won!!! :D";
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        
        
        QuestManager.SetNormalQuestStatus(3,true);
        RiddleManager.Instance.RiddleSolved();
        QuestManager.SetNormalQuestStatus(3,true);
        
    }

    public void Lose()
    {
        
        
        if (!alreadyStarted)
        {
            alreadyStarted = true;
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.GetComponent<CanvasGroup>().interactable = true;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            player.GetComponent<ThirdPersonController>().LockCameraPosition = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            text.text = "You left more foxes than chickens on one of the shores :( Your chickens are eaten.";
            StartCoroutine(AutoRestart());
        }
            
    }

    private IEnumerator AutoRestart()
    {
        
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 0;
        text.text = "You left more foxes than chickens on one of the shores :( Your chickens are eaten.\nRestarting in 3..";
        yield return new WaitForSecondsRealtime(1);
        text.text = "You left more foxes than chickens on one of the shores :( Your chickens are eaten.\nRestarting in 2..";
        yield return new WaitForSecondsRealtime(1);
        text.text = "You left more foxes than chickens on one of the shores :( Your chickens are eaten.\nRestarting in 1..";
        yield return new WaitForSecondsRealtime(1);
        Restart();

        yield break;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        RiddleManager.Instance.FailPuzzle();
    }
}
