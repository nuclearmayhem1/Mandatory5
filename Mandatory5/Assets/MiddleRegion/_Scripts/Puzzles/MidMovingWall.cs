using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidMovingWall : MonoBehaviour
{
    public float wallSpeed = 15f;
    private Vector3 wallSpawnPosition;

    private void Start()
    {
        wallSpawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (wallSpeed * Time.deltaTime), transform.position.y,
            transform.position.z);

        //transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);

        if (Time.timeScale < 1)
        {
            transform.position = wallSpawnPosition;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().Move(Vector3.left * Time.deltaTime * -5);
        }
    }
}
