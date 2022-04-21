using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDeathCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().position = new Vector3(0f, 0f, 0f);
        }
    }
}
