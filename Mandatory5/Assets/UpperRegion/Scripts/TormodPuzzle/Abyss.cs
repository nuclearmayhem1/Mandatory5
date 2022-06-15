using StarterAssets;
using UnityEngine;

public class Abyss : MonoBehaviour {

    [SerializeField] private Transform respawnPoint;

    public static Abyss Instance;

    private Transform _playerTransform;

    private void Awake() {
        Instance = this;
        _playerTransform = FindObjectOfType<ThirdPersonController>().transform;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            RespawnPlayer();
        } else if (other.TryGetComponent<Boulder>(out var boulder)) {
            boulder.DestroySelf();
        }
    }

    public void RespawnPlayer() {
        _playerTransform.position = respawnPoint.position;
    }
}