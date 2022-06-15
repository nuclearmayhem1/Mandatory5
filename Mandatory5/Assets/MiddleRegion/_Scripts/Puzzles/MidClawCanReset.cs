using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidClawCanReset : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            other.transform.localPosition = new Vector3(5.5f, 7.59f, -0.69f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            other.transform.localPosition = new Vector3(5.5f, 7.59f, -0.69f);
        }
    }
}
