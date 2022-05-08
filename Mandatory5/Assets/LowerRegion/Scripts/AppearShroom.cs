using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearShroom : MonoBehaviour
{
    public GameObject shroomBody, decoy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DecoyShroom")
        {
            Destroy(decoy);
            shroomBody.SetActive(true);
        }
    }
}
