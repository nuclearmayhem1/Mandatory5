using UnityEngine;

public class Abyss : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //respawn that mofo
        } else if (other.TryGetComponent<Boulder>(out var boulder)) {
            boulder.DestroySelf();
        }
    }
}