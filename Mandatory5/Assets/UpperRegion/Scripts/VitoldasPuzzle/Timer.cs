using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerSeconds;
    public bool timerRunning = false;

    [SerializeField] private TMPro.TextMeshProUGUI timerText;
    
    private float resetSeconds;
    private Animator animator;

    private void Awake()
    {
        resetSeconds = timerSeconds;
        animator = GetComponent<Animator>();
    }

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
                BeanRescueManager.Instance.reset = true;
                BeanRescueManager.Instance.beansRescued = 0;

                animator.SetTrigger("GameEnd");

                BeanRescueManager.Instance.enabled = false;
            }

            if (BeanRescueManager.Instance.beansRescued == BeanRescueManager.Instance.beanCount)
            {
                timerText.text = "You Win!";
                timerSeconds = 0;
                timerRunning = false;;

                animator.SetTrigger("GameEnd");

                BeanRescueManager.Instance.enabled = false;
            }
        }
    }

    public void DisableCanvas()
    {
        timerSeconds = resetSeconds;
        gameObject.SetActive(false);
    }
}
