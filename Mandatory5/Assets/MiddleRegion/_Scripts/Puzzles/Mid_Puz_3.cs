using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Puz_3 : MonoBehaviour
{
    public string pickUpName;

    private Mid_Puz_Door3 door3; 


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        door3 = GameObject.Find("Door").GetComponent<Mid_Puz_Door3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if(pickUpName == ("Brush1"))
            {
                door3.brushOne = true;
                
            }
            if (pickUpName == ("Brush2"))
            {
                door3.brushTwo = true;


                
            }
            if (pickUpName == ("Brush3"))
            {
                door3.brushThree = true;


            }
            gameObject.SetActive(false); 
        }
    }

}
