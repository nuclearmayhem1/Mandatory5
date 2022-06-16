using UnityEngine;

public class RotationCopyCat : MonoBehaviour {

    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    private Vector3 _originalRotation;

    private void Awake() {
        _originalRotation = transform.rotation.eulerAngles;
    }

    public void Rotate(float rotationAngle) {
        transform.rotation = Quaternion.Euler(_originalRotation + rotationAxis * rotationAngle);
    }
}