using System;
using UnityEngine;

public class BoulderHole : MonoBehaviour {

    [field: SerializeField] public GameObject CorrectHoleIndicator { get; private set; }
    
    public static event Action OnStateChanged;
    
    private Boulder _currentBoulder;
    
    private void OnTriggerEnter(Collider other) {
        if (_currentBoulder == null && other.TryGetComponent<Boulder>(out var boulder)) {
            _currentBoulder = boulder;
            _currentBoulder.OnDestroyed += OnBoulderDestroyed;
            _currentBoulder.Deactivate();
            OnStateChanged?.Invoke();
        }
    }

    private void OnBoulderDestroyed() {
        _currentBoulder = null;
        OnStateChanged?.Invoke();
    }

    private void Update() {
        if (_currentBoulder != null)
            _currentBoulder.transform.position = Vector3.MoveTowards(_currentBoulder.transform.position,
                transform.position, Time.deltaTime);
    }
    
    public bool IsBoulderSlotted => _currentBoulder != null;
}