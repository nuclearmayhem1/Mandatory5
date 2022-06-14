using System.Collections;
using Quests;
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
    public int dialogueNumber = 0;

    private bool isRunning, resetting;

    void Start()
    {
        dialogueNumber = 0;

        resetting = false;

        Text = gameObject.GetComponent<TMP_Text>();
        CurrentText = _dialogue[0];
        StartCoroutine(DisplayText());

    }

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

        foreach (char c in CurrentText.ToCharArray())
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

            if (dialogueNumber == _dialogue.Length - 1)
            {
                if (RiddleManager.Instance)
                {
                    RiddleManager.Instance.StartNextRiddle(RiddleManager.Instance.currentRiddle);
                }
            }
            if (dialogueNumber == _dialogue.Length)
            {
                skipAllDialogue();
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