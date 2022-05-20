using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyShroomController : MonoBehaviour
{
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
