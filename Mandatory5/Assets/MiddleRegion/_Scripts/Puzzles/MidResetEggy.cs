using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidResetEggy : MonoBehaviour
{
    public Vector3 StartingPosition;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = StartingPosition;   
    }


}
