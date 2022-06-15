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
            GameManager.Instance.SetItem("Egg");
            Debug.Log("CONGRATULEGGTIONS");
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetItem("Egg");
            Debug.Log("CONGRATULEGGTIONS");
            Destroy(this.gameObject);
        }
        
        
    }
}
