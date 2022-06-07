using UnityEngine;

public class Capstan : MonoBehaviour {

    [SerializeField] private Vector2 rotationRange;
    [SerializeField] private Vector2 outputValueRange;
    [SerializeField] private CapstanHandle[] capstanHandles;

    private float _yRotation; //Might have to locally track as unity rotation loops when going outside 0-360deg
    
    
    
}