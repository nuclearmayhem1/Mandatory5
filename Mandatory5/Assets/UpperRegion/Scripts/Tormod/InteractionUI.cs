using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour {

    [SerializeField] private GameObject interactionPopup;
    [SerializeField] private Text keyText;

    private Camera _cam;

    private void Awake() {
        _cam = Camera.main;
        if (_cam == null) {
            Debug.LogWarning("No camera found!");
            Destroy(this); //Prevent future error
        }
        
        Capstan.OnIndicator += OnIndicator;
        Capstan.OnIndicatorPosition += OnIndicatorPosition;
    }

    private void OnDestroy() {
        Capstan.OnIndicator -= OnIndicator;
        Capstan.OnIndicatorPosition -= OnIndicatorPosition;
    }

    private void OnIndicator(bool state, KeyCode key) {
        interactionPopup.SetActive(state);
        keyText.text = key.ToString();
    }
    
    private void OnIndicatorPosition(Vector3 position) {
        interactionPopup.transform.position = _cam.WorldToScreenPoint(position);
    }
}