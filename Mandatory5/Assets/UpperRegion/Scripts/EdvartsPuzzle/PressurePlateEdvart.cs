using UnityEngine;
using UnityEngine.Events;

public class PressurePlateEdvart :  MonoBehaviour
{
    public Animator plateAnim;
    public float getOffDelay = 0;
    public bool singleActivation = false;
    public bool showTimer = false;
    public UnityEvent onPressurePlate;
    public UnityEvent offPressurePlate;
    public AudioClip pressurePlateSoundUp;
    public AudioClip pressurePlateSoundDown;

    
    private PuzzleManagerEdvart manager;
    private Collider trigger;
    private AudioSource pressurePlate;
    private bool isActive;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManagerEdvart>();
        trigger = GetComponent<Collider>();
        pressurePlate = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isActive) 
        {
            plateAnim.SetBool("IsActive", true);
            pressurePlate.clip = pressurePlateSoundDown;
            pressurePlate.Play();
            onPressurePlate.Invoke();
            isActive = true;
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
        pressurePlate.clip = pressurePlateSoundUp;
        pressurePlate.Play();
        offPressurePlate.Invoke();
        isActive = false;
    }
}
