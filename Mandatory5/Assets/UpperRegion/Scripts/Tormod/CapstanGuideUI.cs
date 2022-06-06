using UnityEngine;

public class CapstanGuideUI : MonoBehaviour {

    private Canvas _canvas;
    
    private void Awake() {
        _canvas = GetComponent<Canvas>();
        CapstanHandle.OnPushState += OnPushState;
    }

    private void OnDestroy() => CapstanHandle.OnPushState -= OnPushState;

    private void OnPushState(bool state) {
        _canvas.enabled = state;
    }
}