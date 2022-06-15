using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleThreeGateOpener : MonoBehaviour
{
    [SerializeField] private GameObject gate;

    [SerializeField] private bool shroomPresent;

    private void Update()
    {
        Animator gateAnim = gate.GetComponent<Animator>();
        
        if (shroomPresent)
        {
            //Set gate speed to 1 to play the animation
            gateAnim.SetFloat("GateOpenSpeed", 1);
        }
        else
        {
            //Makes sure speed is on 0 so animation doesn't play
            gateAnim.SetFloat("GateOpenSpeed", 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PushShroom"))
        {
            shroomPresent = true;
        }
    }
}
