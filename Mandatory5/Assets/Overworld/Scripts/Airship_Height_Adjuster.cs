using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship_Height_Adjuster : MonoBehaviour
{

    public float targetHeight, adjustmentForce;
    
    public Rigidbody airship;

    private void OnTriggerStay(Collider col)
    {
        if (col.transform == airship.transform)
        {
            Vector3 forceDir = new Vector3(0f, Mathf.Clamp(targetHeight - airship.transform.position.y, -10f, 10f), 0f);
            airship.AddForce(forceDir * adjustmentForce, ForceMode.Force);
        }
    }
}
