using UnityEngine;

public class CapstanGuideUI : MonoBehaviour {

    private Canvas _canvas;
    
    private void Awake() {
        _canvas = GetComponent<Canvas>();
        Capstan.OnPushState += OnPushState;
    }

    private void OnDestroy() => Capstan.OnPushState -= OnPushState;

    private void OnPushState(bool state) {
        _canvas.enabled = state;
    }
}