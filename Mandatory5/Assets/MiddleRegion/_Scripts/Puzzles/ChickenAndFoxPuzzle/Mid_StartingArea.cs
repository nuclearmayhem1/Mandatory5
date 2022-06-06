using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_StartingArea : MonoBehaviour
{
    public List<GameObject> animalsInStartingArea;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something left the trigger");
        if (other.CompareTag("Fox") || other.CompareTag("Chicken"))
        {
            animalsInStartingArea.Remove(other.gameObject);
        }
    }
}
