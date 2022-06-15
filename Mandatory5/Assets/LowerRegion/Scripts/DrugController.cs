using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugController : MonoBehaviour
{
    Vector3 startScale;
    Vector3 fullScale;
    public float scaleX = 40;
    public float scaleY = 40;
    public float scaleZ = 40;
    public float speed = 1;
    private bool isIn = false;
    
    void Start()
    {                                                           //Saves its current scale and the custom scale put into the unity editor.
                                                                //As two different vectors.
        startScale = transform.localScale;
        fullScale = new Vector3(scaleX, scaleY, scaleZ);
        isIn = false;
    }

    void OnTriggerStay(Collider other)                          //When player is staying it, it expands from the initial vector transform to the second one.
                                                                //It also let's the player drug controller that its under spore effects so other environmental
                                                                //effects can start happening.
    {
        if(other.CompareTag("Player"))
        {
            var step = speed * Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, fullScale, step);
            isIn = true;
            PlayerDrugChecker.isHigh = true;
        }
    }

    private void OnTriggerExit(Collider other)                  //Flips bools letting the object know the player isn't in and is no longer affected by spores.
    {
        if(other.CompareTag("Player"))
        {
            isIn = false;
            PlayerDrugChecker.isHigh = false;
        }
    }

    private void Update()
    {
        if(isIn == false)       //If the player is no longer inside, the object starts shrinking to its initial start size.
        {
            var step = speed * Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, step);
        }
    }
}
