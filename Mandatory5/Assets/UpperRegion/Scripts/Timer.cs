using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerSeconds;
    [SerializeField] private TMPro.TextMeshProUGUI timerText;
    
    private bool timerRunning = false;

    private void Start()
    {
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning)
        {
            if (timerSeconds > 0)
            {
                timerSeconds -= Time.deltaTime;
                timerText.text = ((int)timerSeconds).ToString();
            }
            else
            {
                timerText.text = "You Lost!";
                timerSeconds = 0;
                timerRunning = false;
            }
        }
    }
}
