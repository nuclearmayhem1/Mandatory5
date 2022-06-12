using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapstanHandle : MonoBehaviour {
    
    public bool InRange { get; private set; }

    private Capstan _capstan;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        _capstan.InvokeOnIndicator(true);
        InRange = true;
    }

    private void OnTriggerStay(Collider other) {
        _capstan.InvokeOnIndicatorPosition(transform.position);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player")) return;
        _capstan.InvokeOnIndicator(false);
        InRange = false;
    }

    public void SetCapstan(Capstan capstanToSet) => _capstan = capstanToSet;


}