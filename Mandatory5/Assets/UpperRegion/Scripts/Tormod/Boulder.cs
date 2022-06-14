using System;
using UnityEngine;

public class Boulder : MonoBehaviour {
    
    private Rigidbody _rb;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rb.AddForce(Vector3.down * 100f, ForceMode.Force); //Extra gravity
    }

    //Destroy itself on impact with another boulder
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.TryGetComponent<Boulder>(out var boulder)) {
            Destroy(boulder.gameObject);
            Destroy(gameObject);
        }
    }
}