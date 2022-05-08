using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugController : MonoBehaviour
{
    Vector3 startScale;
    Vector3 fullScale;
    public float scale = 40;
    public float speed = 1;
    private bool isIn = false;
    
    void Start()
    {
        startScale = transform.localScale;
        fullScale = new Vector3(scale, scale, scale);
        isIn = false;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var step = speed * Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, fullScale, step);
            isIn = true;
            PlayerDrugChecker.isHigh = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isIn = false;
            PlayerDrugChecker.isHigh = false;
        }
    }

    private void Update()
    {
        if(isIn == false)
        {
            var step = speed * Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, step);
        }
    }
}
