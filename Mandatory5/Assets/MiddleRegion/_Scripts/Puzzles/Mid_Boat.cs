using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Boat : MonoBehaviour
{
    private Animator boatAnimator;
    public GameObject animal1, animal2;
    public bool boatIsFull;


    // Start is called before the first frame update
    void Start()
    {
        boatAnimator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The player touched the boat");
            if (Input.GetKeyUp(KeyCode.E) && boatIsFull)
            {
                boatAnimator.SetBool("Two animals", true);
                Debug.Log("The boat is going again");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boatAnimator.SetBool("Two animals", false);
        }
    }
    private void OnTriggerEnter(Collider other) //The issue is that all the if statements are true at the same time.
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
