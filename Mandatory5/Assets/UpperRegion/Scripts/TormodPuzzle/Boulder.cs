using System;
using UnityEngine;

public class Boulder : MonoBehaviour {
    
    [SerializeField] private float maxLifetime = 15f;
    [SerializeField] private GameObject destroyParticlesPrefab;
    
    public event Action OnDestroyed;

    private Rigidbody _rb;
    private bool _deactivated;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        Invoke(nameof(DestroySelf), maxLifetime); //Invoke instead of just Destroy, as we want to be able to cancel it
    }

    private void OnDestroy() {
        OnDestroyed?.Invoke();
    }

    private void FixedUpdate() {
        if (_rb != null)
            _rb.AddForce(Vector3.down * 100f, ForceMode.Force); //Extra gravity
    }

    //Destroy itself on impact with another boulder
    private void OnCollisionEnter(Collision collision) {
        if (_deactivated) return;
        if (collision.collider.TryGetComponent<Boulder>(out var boulder)) {
            boulder.DestroySelf();
            DestroySelf();
        } else if (collision.collider.CompareTag("Player") && _rb != null) { //Check rb to make sure it is live
            Abyss.Instance?.RespawnPlayer();
        }
    }

    public void DestroySelf() {
        Instantiate(destroyParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public void Deactivate() {
        _deactivated = true;
        CancelInvoke(); //Cancel destroy invoke from awake
        Destroy(_rb);
    }
}