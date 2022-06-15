using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField] private bool startSpawningOnAwake;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float spawnIntervalOffset;
    [SerializeField] private GameObject prefabToSpawn;

    private void Awake() {
        if (startSpawningOnAwake)
            StartSpawning();
    }

    public void StartSpawning() {
        InvokeRepeating(nameof(SpawnObject), spawnIntervalOffset, spawnInterval);
    }

    private void SpawnObject() {
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
    
}