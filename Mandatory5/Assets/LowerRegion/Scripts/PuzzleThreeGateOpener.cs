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
            gateAnim.SetFloat("GateOpenSpeed", 1);
        }
        else
        {
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
