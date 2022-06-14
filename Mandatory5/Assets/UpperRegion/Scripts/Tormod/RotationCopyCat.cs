using UnityEngine;

public class RotationCopyCat : MonoBehaviour {

    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    public void Rotate(float rotationAngle) {
        transform.rotation = Quaternion.Euler(rotationAxis * rotationAngle);
    }
}