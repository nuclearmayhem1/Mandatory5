using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 currentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15)
        {
            transform.position = startPosition;
        }
    }
}
