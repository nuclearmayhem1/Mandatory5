using System.Collections;
using System.Collections.Generic;
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
            if (brushOne)
            {
                audio_Clips.PlayAudioOne();
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
                audio_Clips.PlayAudioOne();
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

    void TurnOnDoor()
    {
        Invoke("ChangeDoorMat", 3f);
    }

    void ChangeDoorMat()
    {
        audio_Clips.PlayAudioTwo();
        gameObject.GetComponent<Renderer>().material = doorFour;
        backWall.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Invoke("RemoveDoorAndSplashMesh", 2f);

    }


    void InvokeSplash()
    {
        Invoke("TurnOffSplashScale", 2f);
    }

    void TurnOffSplashScale()
    {
        doorSplash.scaleDownB = false;
    }
    void RemoveDoorAndSplashMesh()
    {
        doorMat.enabled = false;
        doorSplashMesh.enabled = false;
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
