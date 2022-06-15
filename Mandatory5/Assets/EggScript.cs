using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Egg", 1);
            Debug.Log("CONGRATULEGGTIONS");
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Egg", 1);
            Debug.Log("CONGRATULEGGTIONS");
            Destroy(this.gameObject);
        }
        
        
    }
}
