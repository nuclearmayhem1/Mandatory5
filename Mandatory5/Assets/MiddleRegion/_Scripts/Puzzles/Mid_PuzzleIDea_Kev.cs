using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PuzzleIDea_Kev : MonoBehaviour
{
    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
