using System;
using UnityEngine;

public class Abyss : MonoBehaviour {

    [SerializeField] private Transform respawnPoint;

    private Transform _playerTransform;

    private void Awake() {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //respawn that mofo
        } else if (other.TryGetComponent<Boulder>(out var boulder)) {
            boulder.DestroySelf();
        }
    }

    public void RespawnPlayer() {
        
    }
}