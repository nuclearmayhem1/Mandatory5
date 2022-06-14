using Quests;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Mid_RestartFoxAndChicken : MonoBehaviour
{
    public Text text;

    private void Start()
    {
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
        
        QuestManager.SetNormalQuestStatus(3,true);
        RiddleManager.Instance.RiddleSolved();
        QuestManager.SetNormalQuestStatus(3,true);
        
    }

    public void Lose()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        
        GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>().cursorLocked = true;
        GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>().cursorLocked = true;
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        RiddleManager.Instance.FailPuzzle();
    }
}
