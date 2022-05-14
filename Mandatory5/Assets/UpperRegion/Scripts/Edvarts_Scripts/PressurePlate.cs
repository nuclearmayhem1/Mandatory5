using UnityEngine;
using UnityEngine.Events;

public class PressurePlate :  MonoBehaviour
{
    public Animator plateAnim;
    public float getOffDelay = 0;
    public bool singleActivation = false;
    public bool showTimer = false;
    public UnityEvent onPressurePlate;
    public UnityEvent offPressurePlate;

    
    private PuzzleManager manager;
    private Collider trigger;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManager>();
        trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            plateAnim.SetBool("IsActive", true);
            onPressurePlate.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!singleActivation)
            {
                trigger.enabled = false;
                Invoke("Off", getOffDelay);
                if (showTimer)
                {
                    manager.ResetTimer(getOffDelay);
                }
            }
        }
    }
    private void Off()
    {
        trigger.enabled = true;
        plateAnim.SetBool("IsActive", false);
        offPressurePlate.Invoke();
    }
}
