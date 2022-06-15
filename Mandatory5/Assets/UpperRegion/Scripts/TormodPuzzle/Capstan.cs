using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Capstan : MonoBehaviour {

    [Header("Settings")]
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private float rotationSpeed = 50f;
    
    [Tooltip("The max angle of rotation")] [Range(0, 360)]
    [SerializeField] private float maxRotation = 360f;
    
    [Tooltip("Whether it can rotate infinitely and freely. Allows for rotation in both directions")]
    [SerializeField] private bool unlockedRotation;
    [SerializeField] private UnityEvent<float> onRotate;
    
    [Header("References")]
    [SerializeField] private CapstanHandle[] capstanHandles;
    [SerializeField] private Transform pivot;
    
    public static event Action<bool, KeyCode> OnIndicator; 
    public static event Action<Vector3> OnIndicatorPosition;
    public static event Action<bool> OnPushState; 

    private CapstanHandle _currentHandle;
    private ThirdPersonController _playerController;
    private int _direction;
    private float _currentRotation; //Have to locally track as actual unity rotation is different from what is displayed in the inspector

    private void Awake() {
        _playerController = FindObjectOfType<ThirdPersonController>();
        if (_playerController == null) {
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
                //Enter new push state if the handle is not the current one, and player is in range of said handle
                if (_currentHandle != handle && handle.InRange) {
                    EnterPushState(handle);
                    return;
                }
            }
            ExitPushState();
        }
    }
    
    public void InvokeOnIndicator(bool active) => OnIndicator?.Invoke(active, interactionKey);
    public void InvokeOnIndicatorPosition(Vector3 position) => OnIndicatorPosition?.Invoke(position);

    #region Push State
    private void EnterPushState(CapstanHandle handle) {
        _currentHandle = handle;
        OnIndicator?.Invoke(false, interactionKey);
        OnPushState?.Invoke(true);
        _playerController.canMove = false;
        var playerTransform = _playerController.transform;
        playerTransform.SetParent(pivot);
        
        //Find which side of the handle to know which direction to move
        var handleTransform = handle.transform;
        var handlePosition = handleTransform.position;
        var playerPosition = playerTransform.position;
        var vectorToTarget = (handlePosition - playerPosition).normalized;
        handlePosition.y = playerPosition.y; // Level out y position
        _direction = Vector3.Dot(vectorToTarget, handleTransform.forward) > 0 ? -1 : 1;
        
        //Position the player
        playerTransform.position = handlePosition + handleTransform.forward * .4f * _direction;
        playerTransform.LookAt(handlePosition);
    }

    private void ExitPushState() {
        if (_currentHandle == null) return;
        
        OnIndicator?.Invoke(_currentHandle.InRange, interactionKey); //Pass _inRange in case outside range
        OnPushState?.Invoke(false);
        _playerController.transform.SetParent(null);
        _playerController.canMove = true;
        _currentHandle = null;
    }

    private void HandlePushState() {
        int pushDirection;
        if (Input.GetKey(KeyCode.W)) {
            //Push forward
            pushDirection = -1;
        } else if (Input.GetKey(KeyCode.S)) {
            //Push backward
            pushDirection = 1;
        } else return; //Make sure to not proceed of no movement was made

        var rotationAmount = Time.deltaTime * rotationSpeed * _direction * pushDirection;
        _currentRotation += rotationAmount;
        //Check if capstan can rotate further
        if (!unlockedRotation) {
            _currentRotation = Mathf.Clamp(_currentRotation, 0, maxRotation);
        }
        
        pivot.localRotation = Quaternion.Euler(Vector3.up * _currentRotation);
        onRotate.Invoke(_currentRotation);
    }
    #endregion
}