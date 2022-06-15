using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PaintDispenser : MonoBehaviour
{
    public GameObject brushOnePrefab, brushTwoPrefab, brushThreePrefab;
    public GameObject goalColor;
    public bool buttonsUnlocked;


    private Mid_PaintButton paintButtonOne;
    private Mid_PaintButton paintButtonTwo;
    //private Mid_Audio_Clips audio_Clips;
    private AudioSource audioSource;

    private bool colorOne, colorTwo, colorThree;

    private Transform brushSpawnLoc;
    private Color purple;
    private Color orange;

    private Animator dispenserAnim;
    public GameObject GoPaintDoor;

    


    // Start is called before the first frame update
    void Start()
    {
        dispenserAnim = GameObject.Find("PaintingMechPrefab/BrushDispenserSystem/AnimBox").GetComponent<Animator>();
        audioSource = GameObject.Find("PaintingMechPrefab/BrushDispenserSystem/AnimBox").GetComponent<AudioSource>();

        paintButtonOne = GameObject.Find("ButtonOne").GetComponent<Mid_PaintButton>();
        paintButtonTwo = GameObject.Find("ButtonTwo").GetComponent<Mid_PaintButton>();

        brushSpawnLoc = GameObject.Find("BrushSpawnLoc").GetComponent<Transform>();


       
        goalColor = GameObject.Find("GoalColor");
        goalColor.GetComponent<Renderer>().material.color = Color.green;

        buttonsUnlocked = false;
        colorOne = true;                //Color one + two + three are the goal colors.
        colorTwo = false; 
        colorThree = false;

        purple = new Color32(143, 0, 254, 1);          //Purple and orange colors don't have a preset in unity, and are therefore defined here.
        orange = new Color32(255, 100, 0, 1);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonsUnlocked)                            //In order to call this one script, than both of the buttons to make them interactable.
        {
            paintButtonOne.dispenserActive = true;
            paintButtonTwo.dispenserActive = true;
        }
        if (!buttonsUnlocked)
        {
            paintButtonOne.dispenserActive = false;
            paintButtonTwo.dispenserActive = false;
        }

        if (colorOne) //Yellow + Blue = Green               //colorOne(Two and Three) is two seperate the if statements
                                                            // so that they can be independent of eachother.
        {
           
            if (paintButtonOne.yellow & paintButtonTwo.blue || paintButtonOne.blue & paintButtonTwo.yellow)     //If the colors are the right combination.
            {
                dispenserAnim.SetBool("DispenseBrush", true);               //Play the animation.
                //audio_Clips.PlayAudioOne();
                audioSource.Play();                                         //Play the audio.
                Invoke("SpawnBrushOne", 2);
                //SpawnBrushOne();
                buttonsUnlocked = false;                                    //Turns off the ability to press the buttons.
                                                                            //(This is activated again when using the paintbrush on the door).

                GoPaintDoor.SetActive(true);
                colorTwo = true;                                            //Sets the next color combination bool to be true,
                                                                            //and disables this bool.
                colorOne = false;
            }
            
        }
        if (colorTwo)//Blue + Red = Purple
        {
            if (paintButtonOne.blue & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.blue)           //Same as above.
            {
                dispenserAnim.SetBool("DispenseBrush", true);
                //audio_Clips.PlayAudioOne();
                audioSource.Play();
                Invoke("SpawnBrushTwo", 2);
                //SpawnBrushTwo();
                buttonsUnlocked = false;
                GoPaintDoor.SetActive(true);
                colorThree = true;
                colorTwo = false;
            }
        }
        if (colorThree)// Yellow + Red = Orange
        {
            if (paintButtonOne.yellow & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.yellow)               //Same as above.
            {
                dispenserAnim.SetBool("DispenseBrush", true);
                //audio_Clips.PlayAudioOne();
                audioSource.Play();
                Invoke("SpawnBrushThree", 2);
                //SpawnBrushThree();
                buttonsUnlocked = false;
                GoPaintDoor.SetActive(true);
                
                colorThree = false;
            }

        }
    }

    private void SpawnBrushOne()
    {
        Instantiate(brushOnePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);            //Spawns the first brush prefab.
        dispenserAnim.SetBool("DispenseBrush", false);                                          //Plays the second animation for the dispenser. Lifts the arm.
        //audio_Clips.PlayAudioOne();
        audioSource.Play();                                                                     //Play the audio.

        goalColor.GetComponent<Renderer>().material.color = purple;                             //Changes the color of the object that visualizes the goal color.

    }
    private void SpawnBrushTwo()                                                                //Same as above.
    {
        Instantiate(brushTwoPrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        dispenserAnim.SetBool("DispenseBrush", false);
        //audio_Clips.PlayAudioOne();
        audioSource.Play();

        goalColor.GetComponent<Renderer>().material.color = orange;



    }
    private void SpawnBrushThree()                                                              //Same as above.
    {
        Instantiate(brushThreePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        dispenserAnim.SetBool("DispenseBrush", false);
        //audio_Clips.PlayAudioOne();
        audioSource.Play();



    }

}
