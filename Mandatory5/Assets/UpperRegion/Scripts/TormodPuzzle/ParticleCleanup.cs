using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleCleanup : MonoBehaviour {
    //Destroy particle after it is done playing
    private void Start() => Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
}