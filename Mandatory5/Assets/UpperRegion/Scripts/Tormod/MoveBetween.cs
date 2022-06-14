using UnityEngine;

public class MoveBetween : MonoBehaviour {

    [Tooltip("Position is local. Where the movable object will be moved to after 360 degrees of capstan rotation")]
    [SerializeField] private Vector3 targetPosition;

    private Vector3 _origin;
    private Vector3 _moveDirection;

    private void Awake() {
        _origin = transform.position;
        _moveDirection = targetPosition / 360f;
    }

    public void Move(float moveAmount) {
        transform.position = _origin + _moveDirection * moveAmount;
    }
}