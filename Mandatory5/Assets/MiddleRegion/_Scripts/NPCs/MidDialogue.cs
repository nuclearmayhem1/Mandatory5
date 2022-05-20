using System.Collections;
using UnityEngine;
using TMPro;
 
public class MidDialogue : MonoBehaviour
{
    const string kAlphaCode = "<color=#00000000>";
    const float kMaxTextTime = 0.1f;
    public static int TextSpeed = 2;
 
    private TMP_Text Text;
    private string CurrentText;

    public string[] _dialogue;
    private int dialogueNumber = 0;

    private bool isRunning, resetting;
    
    // Animator Anim;
 
    void Start()
    {
        dialogueNumber = 0;
        
        resetting = false;
        
        Text = gameObject.GetComponent<TMP_Text>();
        CurrentText = _dialogue[0];
        StartCoroutine(DisplayText());
        
        // Anim = GetComponent<Animator>();
        // if (Anim == null)
        // {
        //     Debug.LogError("No Animator Controller on DialogueWindow: " + gameObject.name);
        // }
    }
 
    // public void Show(string text)
    // {
    //     Anim?.SetBool("Open", true);
    //     CurrentText = text;       
    // }
    
    // public void Close()
    // {        
    //     Anim?.SetBool("Open", false);
    // }
    
    // public void OnDialogueOpen()
    // {
    //     StartCoroutine(DisplayText());
    // }
 
    // public void OnDialogueClosed()
    // {
    //     StopAllCoroutines();
    //     Text.text = "";
    // }
 
    private IEnumerator DisplayText()
    {
        isRunning = true;
        if (Text == null)
        {
            Debug.LogError("Text is not linked in DialogueWindow: " + gameObject.name);
            yield return null;
        }
 
        Text.text = "";
 
        string originalText = CurrentText;
        string displayedText = "";
        int alphaIndex = 0;
 
        foreach(char c in CurrentText.ToCharArray())
        {
            alphaIndex++;
            Text.text = originalText;
            displayedText = Text.text.Insert(alphaIndex, kAlphaCode);
            Text.text = displayedText;
 
            yield return new WaitForSecondsRealtime(kMaxTextTime / TextSpeed);
        }
 
        yield return null;

        isRunning = false;
    }

    public void NextDialogue()
    {
        if (isRunning)
        {
            StopAllCoroutines();
            Text.text = _dialogue[dialogueNumber];
            isRunning = false;
        }
        else
        {
            resetting = false;
            StopAllCoroutines();
            
            dialogueNumber += 1;
            
            if (dialogueNumber < _dialogue.Length)
            {
                CurrentText = _dialogue[dialogueNumber];
                
                StartCoroutine(DisplayText());
            }
        
            if (dialogueNumber == _dialogue.Length)
            {
                skipAllDialogue();
            }

            if (RiddleManager.Instance.currentRiddle == 0)
            {
                if (dialogueNumber == 3)
                {
                    RiddleManager.Instance.StartFirstRiddle(_dialogue[dialogueNumber]);
                }
            }
        }
        
        
    }


    public void skipAllDialogue()
    {
        if (!resetting)
        {
            resetting = true;
            StopAllCoroutines();
        
            dialogueNumber = 0;
        
            gameObject.transform.parent.parent.gameObject.GetComponent<ChickenCanvasController>().resetSpeech();
        
            transform.parent.GetComponent<Animator>().SetBool("StartAnim", false);
            
        }
        
        
    }

}