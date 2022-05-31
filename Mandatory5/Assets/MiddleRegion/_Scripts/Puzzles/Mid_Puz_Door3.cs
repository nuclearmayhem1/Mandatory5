using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_Puz_Door3 : MonoBehaviour
{

    public bool brushOne = false;
    public bool brushTwo = false;
    public bool brushThree = false;
    
    
    
    private bool inContactWithPlayer;
    private Renderer doorMat;
    private GameObject backWall;
    private GameObject textPressE;
    private Mid_3_Splash doorSplash;
    private Mid_PaintDispenser paintDispenser;


    [SerializeField]
    private Material doorOne;
    [SerializeField]
    private Material doorTwo;

    [SerializeField]
    private Material doorThree;

    [SerializeField]
    private Material doorFour;

    [SerializeField]
    private Material doorTrans;

    




    // Start is called before the first frame update
    void Start()
    {
        doorMat = gameObject.GetComponent<Renderer>();
        gameObject.GetComponent<Renderer>().material = doorTrans;
        backWall = GameObject.Find("Walls/BackWall");
        textPressE = GameObject.Find("TextPressE");
        textPressE.SetActive(false);
        doorSplash = GameObject.Find("DoorSplash").GetComponent<Mid_3_Splash>();

        paintDispenser = GameObject.Find("PaintDispenser").GetComponent<Mid_PaintDispenser>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inContactWithPlayer)
        {
            if (brushOne)
            {
                doorSplash.MaterialOne();
                doorSplash.ResetScale();
                doorSplash.scaleDownB = true;
                InvokeSplash();
                textPressE.SetActive(false);
                paintDispenser.buttonsUnlocked = true; 



                gameObject.GetComponent<Renderer>().material = doorOne;
                brushOne = false;
            }

            if (brushTwo)
            {
                doorSplash.MaterialTwo();
                doorSplash.ResetScale();
                doorSplash.scaleDownB = true;
                InvokeSplash();
                textPressE.SetActive(false);
                paintDispenser.buttonsUnlocked = true;



                gameObject.GetComponent<Renderer>().material = doorTwo;

                brushTwo = false;
            }

            if (brushThree)
            {
                doorSplash.MaterialThree();
                doorSplash.ResetScale();
                doorSplash.scaleDownB = true;
                InvokeSplash();



                gameObject.GetComponent<Renderer>().material = doorThree;

                TurnOnDoor();
                textPressE.SetActive(false);

                brushThree = false;
            }
        }
    }

    void TurnOnDoor()
    {
        Invoke("ChangeDoorMat", 3f);
    }

    void ChangeDoorMat()
    {
        gameObject.GetComponent<Renderer>().material = doorFour;
        backWall.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false; 

    }


    void InvokeSplash()
    {
        Invoke("TurnOffSplashScale", 2f);
    }

    void TurnOffSplashScale()
    {
        doorSplash.scaleDownB = false;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = true;

            if ((brushOne) || (brushTwo) || (brushThree))
            {
                textPressE.SetActive(true);
            }
                
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = false;
            textPressE.SetActive(false);

        }
    }
}
