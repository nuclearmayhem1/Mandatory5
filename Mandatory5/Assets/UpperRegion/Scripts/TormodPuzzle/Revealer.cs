using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Revealer : MonoBehaviour {

    [SerializeField] private UnityEvent onCompleted;
    [SerializeField] private List<ArtifactObject> artifactObjects;
    [SerializeField] private GameObject[] artifactIndicators;

    private int _artifactsSlotted;

    private void Awake() {
        if (artifactIndicators.Length != artifactObjects.Count) {
            Debug.LogError("Revealer set up incorrectly: amount of objects should be same as amount of indicators!");
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<ArtifactObject>(out var artifactObject) && artifactObjects.Contains(artifactObject)) {
            var index = artifactObjects.IndexOf(artifactObject);
            var artifactIndicator = artifactIndicators[index];

            _artifactsSlotted++;
            artifactObject.Drop(artifactIndicator.transform.position);
            Destroy(artifactObject); //Destroys just the MonoBehaviour
            artifactIndicator.SetActive(false);
            
            if (_artifactsSlotted >= artifactObjects.Count) onCompleted.Invoke();
        }
    }
}