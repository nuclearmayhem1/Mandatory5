using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapstanHandle : MonoBehaviour {
    
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private float rotationSpeed = 50f;
    
    public static event Action<bool, KeyCode> OnIndicator; 
    public static event Action<Vector3> OnIndicatorPosition;
    public static event Action<bool> OnPushState; 

    private static CapstanHandle _currentHandle;
    private bool _inRange;
    private PlayerInput _playerInput;
    private Transform _pivot;

    private void Awake() {
        _pivot = transform.parent;
        _playerInput = FindObjectOfType<PlayerInput>();
        if (_playerInput == null) {
            Debug.LogWarning("No player input found!");
            Destroy(this); //Prevent future error
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        OnIndicator?.Invoke(true, interactionKey);
        _inRange = true;
    }

    private void OnTriggerStay(Collider other) {
        OnIndicatorPosition?.Invoke(transform.position);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player")) return;
        OnIndicator?.Invoke(false, interactionKey);
        _inRange = false;
    }

    private void Update() {
        CheckInteraction();
        if (_currentHandle == this)
            HandlePushState();
    }

    private void CheckInteraction() {
        var keyPressed = Input.GetKeyDown(interactionKey);
        if (keyPressed && _inRange) {
            if (_currentHandle == this) ExitPushState();
            else EnterPushState();
        }
    }

    private void EnterPushState() {
        _currentHandle = this;
        OnIndicator?.Invoke(false, interactionKey);
        OnPushState?.Invoke(true);
        _playerInput.enabled = false;
        _playerInput.transform.SetParent(_pivot); //transform.parent is pivot
    }

    private void ExitPushState() {
        _currentHandle = null;
        OnIndicator?.Invoke(true, interactionKey);
        OnPushState?.Invoke(false);
        _playerInput.enabled = true;
        _playerInput.transform.SetParent(null);

    }

    private void HandlePushState() {
        if (Input.GetKey(KeyCode.W)) {
            //Push forward
            _pivot.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            //Push backward
            _pivot.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
}