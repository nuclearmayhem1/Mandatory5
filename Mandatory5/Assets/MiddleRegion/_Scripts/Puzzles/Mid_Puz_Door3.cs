using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;

public class Mid_Puz_Door3 : MonoBehaviour
{

    public bool brushOne = false;
    public bool brushTwo = false;
    public bool brushThree = false;



    private Mid_Audio_Clips audio_Clips;
    private bool inContactWithPlayer;
    private Renderer doorMat;
    private GameObject backWall;
    private GameObject textPressE;
    private MeshRenderer doorSplashMesh;
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


    public GameObject GoGetPaint;



    // Start is called before the first frame update
    void Start()
    {
        doorMat = gameObject.GetComponent<Renderer>();
        gameObject.GetComponent<Renderer>().material = doorTrans;
        backWall = GameObject.Find("Walls/BackWall");
        textPressE = GameObject.Find("TextPressE");
        textPressE.SetActive(false);
        doorSplash = GameObject.Find("DoorSplash").GetComponent<Mid_3_Splash>();
        doorSplashMesh = GameObject.Find("DoorSplash").GetComponent<MeshRenderer>();

        paintDispenser = GameObject.Find("PaintDispenser").GetComponent<Mid_PaintDispenser>();
        audio_Clips = GameObject.Find("PaintingMechPrefab/Door").GetComponent<Mid_Audio_Clips>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inContactWithPlayer)
        {
            if (brushOne)                       //When player is close enough to the door and press "E" + the bool is true
                                                //(Set true when collecting the brush)
            {
                audio_Clips.PlayAudioOne();         //Play audio.
                doorSplash.MaterialOne();           //Calls method in doorSplash script to change the material.
                doorSplash.ResetScale();            //Resets the scale of the doorSplach gameobject.
                doorSplash.scaleDownB = true;       //Bool is set to true. This causes the gameobject to scale down in size.
                InvokeSplash();                     //An invoke method - Sets the scaleDown to be false after x seconds.
                textPressE.SetActive(false);            //Deactivates text gameobject.
                paintDispenser.buttonsUnlocked = true;
                    //Unlocks the Buttons on the paint dispenser system.
                GoGetPaint.SetActive(false);


                gameObject.GetComponent<Renderer>().material = doorOne;             //Changes the doors material to be = doorOne. 
                brushOne = false;                                               //Sets bool to false = Removes the brush from the "inventory".
            }

            if (brushTwo)                                   //Same as above.
            {
                audio_Clips.PlayAudioOne();
                doorSplash.MaterialTwo();
                doorSplash.ResetScale();
                doorSplash.scaleDownB = true;
                InvokeSplash();
                textPressE.SetActive(false);
                paintDispenser.buttonsUnlocked = true;
                GoGetPaint.SetActive(false);


                gameObject.GetComponent<Renderer>().material = doorTwo;

                brushTwo = false;
            }

            if (brushThree)                             //Same as above.
            {
                audio_Clips.PlayAudioOne();
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

    void TurnOnDoor()                       //Calls the method "ChangeDoorMat()" after a three second delay.
    {
        Invoke("ChangeDoorMat", 3f);
    }

    void ChangeDoorMat()                            //This is the final door material, which visualizes the door.
    {
        audio_Clips.PlayAudioTwo();                                     //Play audio.
        gameObject.GetComponent<Renderer>().material = doorFour;        ///Changes the material.
        backWall.SetActive(false);                                      //Turns off the backWall gameobject.
        gameObject.GetComponent<BoxCollider>().enabled = false;         //Turns off the box collider of this gameobject.
        Invoke("RemoveDoorAndSplashMesh", 2f);                          //Calls the method below after a 2 second delay.

    }


    void InvokeSplash()
    {
        Invoke("TurnOffSplashScale", 2f);           //Invokes method below.
    }

    void TurnOffSplashScale()
    {
        doorSplash.scaleDownB = false;              //Sets the scaledown bool to be false - Turns off the scaling.
    }
    void RemoveDoorAndSplashMesh()                  //Disables the mesh renderer for both the door and the splash gameobject.
    {
        doorMat.enabled = false;
        doorSplashMesh.enabled = false;
        
        QuestManager.SetNormalQuestStatus(7,true);
        
        QuestManager.SetNormalQuestStatus(7,true);
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = true;

            if ((brushOne) || (brushTwo) || (brushThree))
            {
                textPressE.SetActive(true);             //When the player is close enough and has collected one of the brushes
                                                        //- The text gameobject is activated.
            }
                
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = false;                //When the player exits the trigger, the bool is set to false,
                                                        //and the text gameobject is deactivated.
            textPressE.SetActive(false);

        }
    }
}
