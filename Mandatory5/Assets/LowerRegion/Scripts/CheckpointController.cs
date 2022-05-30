using UnityEngine;

//Made by: Aeden
/// <summary>
/// Used as refrence to make the actual Checkpoint and respawn controllers.
/// </summary>

public class CheckpointController : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 currentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
        /*if(transform.position.y < -35)
        {
            transform.position = startPosition;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathPlane"))
        {
            transform.position = startPosition;
        }
    }
}
