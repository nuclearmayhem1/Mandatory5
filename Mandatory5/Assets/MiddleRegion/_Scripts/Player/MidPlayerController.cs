using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPlayerController : MonoBehaviour
{
    //private int respawnNumber;
    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            //respawnNumber = other.GetComponent<MidRespawnPoint>().checkpointNumber;
            respawnPosition = other.gameObject.transform.position;
            Debug.Log("Respawn position set to" + respawnPosition);
        }
        
        if (other.gameObject.CompareTag("DeathCollider"))
        {
            Respawn();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("DeathCollider"))
        {
            Respawn();
        }
    }


    private void Respawn()
    {
        transform.parent.transform.position = respawnPosition;
        Debug.Log("Respawning at" + respawnPosition);
    }
    
}
