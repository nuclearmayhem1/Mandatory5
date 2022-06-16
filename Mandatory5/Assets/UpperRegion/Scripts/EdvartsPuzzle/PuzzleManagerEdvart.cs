using UnityEngine;
using UnityEngine.UI;

public class PuzzleManagerEdvart : MonoBehaviour
{
    [Header("References")]
    public Text timerText;
    public WinMessage solvedMessage;
    public Respawn abyss;
    [HideInInspector] public bool puzzleDone;

    private float timer = 0;

    void Update()
    {
        if(timer > 0)
        {
            timerText.text = timer.ToString("0");
            timer -= Time.deltaTime;
        }
        else
        {
            timerText.text = "";
        }

        if (puzzleDone)
        {
            timer = 0;
        }

    }

    public void ResetTimer(float time)
    {
        timer = time;
    }
    public void PuzzleDone(bool state)
    {
        puzzleDone = state;
    }
    public void RespawnDone(bool state)
    {
        abyss.SetRespawnDone(state);
    }
    public void Message(string message)
    {
        solvedMessage.Message(message);
    }
}
