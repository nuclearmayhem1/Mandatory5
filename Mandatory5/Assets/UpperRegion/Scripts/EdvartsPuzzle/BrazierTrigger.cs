using UnityEngine;

public class BrazierTrigger : MonoBehaviour
{
    [Header("References")]
    public Canvas pressE;
    public ParticleSystem explotion;
    public AudioSource panSource;
    public AudioClip flame;

    private bool canCook;
    private bool haveCooked;
    private PuzzleManagerEdvart manager;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManagerEdvart>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && manager.puzzleDone && !haveCooked)
        {
            EnableE(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && manager.puzzleDone && !haveCooked)
        {
            EnableE(false);
        }
    }
    private void Update()
    {
        if (canCook && Input.GetKeyDown(KeyCode.E))
        {
            if (!haveCooked)
            {
                panSource.clip = flame;
                panSource.loop = false;
                panSource.Play();
                explotion.Play();
                manager.RespawnDone(true);
                manager.Message("Breakfast is cooked");
                haveCooked = true;
                EnableE(false); 
            }
            
        }
    }
    public void EnableE(bool state)
    {
        pressE.enabled = state;
        canCook = state;
    }
}
