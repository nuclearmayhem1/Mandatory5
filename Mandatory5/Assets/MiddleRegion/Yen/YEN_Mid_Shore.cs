using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEN_Mid_Shore : MonoBehaviour
{
    public bool reachedTheShore;
    public Mid_Boat midBoat;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fox") || other.gameObject.CompareTag("Chicken"))
        {
            reachedTheShore = true;
            //other.gameObject.transform.position = 

        }
    }
}
