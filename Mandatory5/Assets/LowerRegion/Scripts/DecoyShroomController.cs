using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyShroomController : MonoBehaviour
{
    //sets a respawnlocation and resets the falling shroom to that location if it hits a deathplane
    private Vector3 startLocation;

    private void Start()
    {
        startLocation = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPlane"))
        {
            transform.position = startLocation;
        }
    }

}
