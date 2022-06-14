using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCup : MonoBehaviour
{
    public GameObject E, egg;
    private bool withinRange;
    private bool readyToChoose;
    public int cupNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        E.GetComponent<CanvasGroup>().alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && readyToChoose)
        {
            E.GetComponent<CanvasGroup>().alpha = 1;
            withinRange = true;

            E.transform.parent.transform.position = new Vector3(gameObject.transform.position.x, E.transform.parent.transform.position.y, gameObject.transform.position.z);

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


        if (gameObject.transform.parent.transform.parent.GetComponent<MidJeff>().bedge)
        {
            readyToChoose = true;
        }

        if (Input.GetKey(KeyCode.E) && withinRange && readyToChoose)
        {
            
            gameObject.transform.parent.transform.parent.GetComponent<Animator>().SetBool("Reveal", true);

            eggCheck();
            

        }





    }


    private void eggCheck()
    {
        egg.SetActive(true);
        egg.GetComponent<Egg>().TeleportToCorrectCup();
        
        Debug.Log("the cup number is " + cupNumber + ", and the correct answer is " + egg.GetComponent<Egg>().posNumber);

        if (egg.GetComponent<Egg>().posNumber == cupNumber)
        {

            transform.parent.transform.parent.GetComponent<MidJeff>().correct = true;

            Debug.Log(" YOU WINNED ");


        }
        else
        {

            transform.parent.transform.parent.GetComponent<MidJeff>().correct = false;
        }
        


    }


}
