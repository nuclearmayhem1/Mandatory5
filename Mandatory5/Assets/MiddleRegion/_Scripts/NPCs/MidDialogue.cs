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

    private bool isRunning;
    
    // Animator Anim;
 
    void Start()
    {
        Text = gameObject.GetComponent<TMP_Text>();
        CurrentText = gameObject.GetComponent<TMP_Text>().text;
        dialogueNumber = 0;
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
        }
        
        
    }


    public void skipAllDialogue()
    {
        StopAllCoroutines();
        gameObject.transform.parent.gameObject.SetActive(false);
        
        
    }

}