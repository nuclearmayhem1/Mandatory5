using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [HideInInspector] public bool puzzleDone; 
    public Text timerText;
    
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
}
