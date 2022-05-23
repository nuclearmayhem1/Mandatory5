using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_FoxAndChicken : MonoBehaviour
{
    public Vector3 startPosition, endPosition1, endPosition2;
    public GameObject ghostAnimal1, ghostAnimal2;

    public void Start()
    {
        startPosition = transform.position;
        endPosition1 = ghostAnimal1.transform.position;
        endPosition2 = ghostAnimal2.transform.position;


    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                transform.position = endPosition1;
            }
        }
    }
}
