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
            // Massive trigger colliders are spread throughout the Overworld scene.
            // Collecting ship parts activates the triggers that lead to the next region.
            // When the airship enters the trigger, it will move in the y-axis towards the desired height.
            // Thus the airship can move up and down cliffs.
            Vector3 forceDir = new Vector3(0f, Mathf.Clamp(targetHeight - airship.transform.position.y, -10f, 10f), 0f);
            airship.AddForce(forceDir * adjustmentForce, ForceMode.Force);
        }
    }
}
