using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
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

    }

    public void ResetTimer(float time)
    {
        timer = time;
    }
}
