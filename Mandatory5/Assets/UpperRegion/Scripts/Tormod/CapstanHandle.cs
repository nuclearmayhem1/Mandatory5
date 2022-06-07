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
    private int _direction;

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
        if (keyPressed) {
            if (_currentHandle != this && _inRange) 
                EnterPushState();
            else ExitPushState();
        }
    }

    private void EnterPushState() {
        _currentHandle = this;
        OnIndicator?.Invoke(false, interactionKey);
        OnPushState?.Invoke(true);
        _playerInput.enabled = false;
        var playerTransform = _playerInput.transform;
        playerTransform.SetParent(_pivot); //transform.parent is pivot
        
        //Find which side of the handle + position the player
        var handlePosition = transform.position;
        var playerPosition = playerTransform.position;
        var vectorToTarget = (handlePosition - playerPosition).normalized;
        handlePosition.y = playerPosition.y;
        playerTransform.position = handlePosition;

        if (Vector3.Dot(vectorToTarget, transform.forward) > 0) { //Where is player related to the handle?
            //Reverse direction
            _direction = -1;
            playerTransform.position -= transform.forward * .2f;
        } else {
            //Normal direction
            _direction = 1;
            playerTransform.position += transform.forward * .2f;
        }

        playerTransform.LookAt(handlePosition);
        
        //Did last: made rotate correct way related to which side. New bug: interacting while walking along handle launches player far
    }

    private void ExitPushState() {
        _currentHandle = null;
        OnIndicator?.Invoke(_inRange, interactionKey); //Pass _inRange in case outside range
        OnPushState?.Invoke(false);
        _playerInput.enabled = true;
        _playerInput.transform.SetParent(null);

    }

    private void HandlePushState() {
        if (Input.GetKey(KeyCode.W)) {
            //Push forward
            _pivot.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed * _direction);
        } else if (Input.GetKey(KeyCode.S)) {
            //Push backward
            _pivot.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * _direction);
        }
    }
}