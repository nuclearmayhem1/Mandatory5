using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnivaCoolScriptingYes : MonoBehaviour
{
    public GameObject animal1, animal2;
    public Animator boatAnimator;
    public bool boatIsFull;
    void Start()
    {
        boatAnimator = gameObject.GetComponentInParent<Animator>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.E) && boatIsFull)
            {
                boatAnimator.SetBool("Two animals", true);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boatAnimator.SetBool("Two animals", false);
        }
    }
    public void OnTriggerEnter(Collider other) //The issue is that all the if statements are true at the same time
    {
        if (other.gameObject.CompareTag("Fox") || other.gameObject.CompareTag("Chicken"))
        {
            if (animal1 == null)
            {
                boatIsFull = false;
                other.gameObject.transform.SetParent(gameObject.transform);
                animal1 = other.gameObject;
            }
            else if (animal1 != null && animal2 == null)
            {
                boatIsFull = false;
                other.gameObject.transform.SetParent(gameObject.transform);
                animal2 = other.gameObject;
            }

            if (animal1 != null && animal2 != null)
            {
                boatIsFull = true;
                animal1.transform.parent = null;
                animal1 = other.gameObject;
            }
        }
    }
}
