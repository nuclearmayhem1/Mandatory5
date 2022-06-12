using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Capstan : MonoBehaviour {
    
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float maxRotation;
    [SerializeField] private Vector2 outputValueRange;
    [SerializeField] private CapstanHandle[] capstanHandles;
    [SerializeField] private Transform pivot;
    
    public static event Action<bool, KeyCode> OnIndicator; 
    public static event Action<Vector3> OnIndicatorPosition;
    public static event Action<bool> OnPushState; 

    private static CapstanHandle _currentHandle;
    private PlayerInput _playerInput;
    private int _direction;
    private float _yRotation; //Might have to locally track as unity rotation loops when going outside 0-360deg

    private void Awake() {
        _playerInput = FindObjectOfType<PlayerInput>();
        if (_playerInput == null) {
            Debug.LogWarning("No player input found!");
            Destroy(this); //Prevent future error
        }

        foreach (var handle in capstanHandles) {
            handle.SetCapstan(this);
        }
    }
    
    private void Update() {
        CheckInteraction();
        if (_currentHandle != null)
            HandlePushState();
    }

    private void CheckInteraction() {
        var keyPressed = Input.GetKeyDown(interactionKey);
        if (keyPressed) {
            foreach (var handle in capstanHandles) {
                //Enter new push state if handle is not the current one, and player is in range of said handle
                if (_currentHandle != handle && handle.InRange) {
                    EnterPushState(handle);
                    return;
                }
            }
            ExitPushState();
        }
    }

    private void EnterPushState(CapstanHandle handle) {
        _currentHandle = handle;
        OnIndicator?.Invoke(false, interactionKey);
        OnPushState?.Invoke(true);
        _playerInput.enabled = false;
        var playerTransform = _playerInput.transform;
        playerTransform.SetParent(pivot); //transform.parent is pivot
        
        //Find which side of the handle + position the player
        var handleTransform = handle.transform;
        var handlePosition = handleTransform.position;
        var playerPosition = playerTransform.position;
        var vectorToTarget = (handlePosition - playerPosition).normalized;
        handlePosition.y = playerPosition.y;
        playerTransform.position = handlePosition;

        if (Vector3.Dot(vectorToTarget, handleTransform.forward) > 0) { //Where is player related to the handle?
            //Reverse direction
            _direction = -1;
            playerTransform.position -= handleTransform.forward * .2f;
        } else {
            //Normal direction
            _direction = 1;
            playerTransform.position += handleTransform.forward * .2f;
        }

        playerTransform.LookAt(handlePosition);
        
        //Did last: made rotate correct way related to which side. New bug: interacting while walking along handle launches player far
    }

    private void ExitPushState() {
        if (_currentHandle == null) return;
        OnIndicator?.Invoke(_currentHandle.InRange, interactionKey); //Pass _inRange in case outside range
        OnPushState?.Invoke(false);
        _playerInput.transform.SetParent(null);
        _playerInput.enabled = true;
        _currentHandle = null;
    }

    private void HandlePushState() {
        var rotationAmount = Time.deltaTime * rotationSpeed * _direction;
        if (Input.GetKey(KeyCode.W)) {
            //Push forward
            pivot.Rotate(-Vector3.up * rotationAmount);
            _yRotation -= rotationAmount;
        } else if (Input.GetKey(KeyCode.S)) {
            //Push backward
            pivot.Rotate(Vector3.up * rotationAmount);
            _yRotation += rotationAmount;
        }

        Debug.Log(_yRotation);
    }

    public void InvokeOnIndicator(bool active) {
        OnIndicator?.Invoke(active, interactionKey);
    }

    public void InvokeOnIndicatorPosition(Vector3 position) {
        OnIndicatorPosition?.Invoke(position);
    }
    
}