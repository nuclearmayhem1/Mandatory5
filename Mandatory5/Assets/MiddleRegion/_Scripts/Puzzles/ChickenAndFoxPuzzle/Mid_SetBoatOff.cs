using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_SetBoatOff : MonoBehaviour
{
    public bool canPressE;
    public Mid_Boat midBoat;
    public Animator boatAnim, buttonAnim;
    public Mid_StartingArea startingArea;


    // Start is called before the first frame update
    void Start()
    {
        startingArea = GameObject.Find("StartingArea").GetComponent<Mid_StartingArea>();
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPressE = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPressE = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (midBoat.boatIsFull || startingArea.endGame == true)
        {
            if (canPressE && Input.GetKeyUp(KeyCode.E))
            {
                buttonAnim.SetBool("buttonPress", true);
                midBoat.boatAnimator.SetBool("Go over", true);
                Invoke("StopButton", 0.5f);
            }
        }
    }

    public void StopButton()
    {
        buttonAnim.SetBool("buttonPress", false);
        midBoat.boatAnimator.SetBool("Go over", false);
    }
}

