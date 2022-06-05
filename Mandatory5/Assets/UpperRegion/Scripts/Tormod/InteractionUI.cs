using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour {

    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
        if (_cam == null) {
            Debug.LogWarning("No camera found!");
            Destroy(this);
        }
    }
}