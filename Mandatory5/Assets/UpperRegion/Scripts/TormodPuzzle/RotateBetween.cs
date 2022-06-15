using UnityEngine;

public class RotateBetween : MonoBehaviour {
    
    [Tooltip("Where the object will rotate to after 360 degrees of capstan rotation. Look at 'local rotation' in the debug inspector to set up correctly!")]
    [SerializeField] private Vector3 targetRotation;
    
    private Vector3 _originalRotation;
    private Vector3 _rotationFraction;

    private void Awake() {
        _originalRotation = transform.rotation.eulerAngles;
        _rotationFraction = (targetRotation - _originalRotation) / 360f;
    }

    public void Rotate(float rotationAngle) {
        transform.rotation = Quaternion.Euler(_originalRotation + _rotationFraction * rotationAngle);
    }
}