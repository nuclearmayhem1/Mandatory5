using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EeeeMid : MonoBehaviour
{

    public GameObject E;
    private bool withinRange;
    private Vector3 ESavedPos;


    // Start is called before the first frame update
    void Start()
    {
        E.GetComponent<CanvasGroup>().alpha = 0;

        ESavedPos = E.transform.parent.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.transform.parent.transform.position = ESavedPos;
            E.GetComponent<CanvasGroup>().alpha = 1;
            withinRange = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.GetComponent<CanvasGroup>().alpha = 0;
            withinRange = false;

        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && withinRange)
        {
            gameObject.GetComponent<Cups>().StartCupAnim();



            GetComponent<Animator>().enabled = true;

           

        }
    }





}
