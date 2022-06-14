using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{
    public GameObject cupsParentObject;
    public Animator cupsAnimator;

    public void Start()
    {
        cupsAnimator = cupsParentObject.GetComponent<Animator>(); //Gets the cup's animator
    }

    public void StartCupAnim()
    {
        
       cupsAnimator.SetBool("Move", true); //Makes the cup start moving
        
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cupsAnimator.SetBool("Move", false);
        }
    }*/
}
