using System;
using UnityEngine;

public class ArtifactObject : MonoBehaviour {

    private static ArtifactObject _currentArtifactObject;
    private bool _pickedUp;
    private Transform _rightHandTransform;

    private void Awake() {
        _rightHandTransform = GameObject.Find("Right_Hand").transform; //Very inefficient, but we cannot edit the player prefab in this project
    }

    private void OnTriggerEnter(Collider other) {
        if (_pickedUp || !other.CompareTag("Player")) return;
        
        if (_currentArtifactObject != null) 
            _currentArtifactObject.Drop(transform.position);
        _currentArtifactObject = this;

        transform.SetParent(_rightHandTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _pickedUp = true;
    }

    public void Drop(Vector3 dropLocation) {
        _pickedUp = false;
        transform.SetParent(null);
        transform.position = dropLocation;
        transform.rotation = Quaternion.identity;
    }
}