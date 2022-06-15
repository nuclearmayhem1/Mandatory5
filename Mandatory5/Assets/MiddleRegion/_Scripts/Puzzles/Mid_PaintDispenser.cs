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
        colorOne = true;
        colorTwo = false; 
        colorThree = false;

        purple = new Color32(143, 0, 254, 1);
        orange = new Color32(254, 161, 0, 1);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonsUnlocked)
        {
            paintButtonOne.dispenserActive = true;
            paintButtonTwo.dispenserActive = true;
        }
        if (!buttonsUnlocked)
        {
            paintButtonOne.dispenserActive = false;
            paintButtonTwo.dispenserActive = false;
        }

        if (colorOne) //Yellow + Blue = Green
        {
           
            if (paintButtonOne.yellow & paintButtonTwo.blue || paintButtonOne.blue & paintButtonTwo.yellow)
            {
                dispenserAnim.SetBool("DispenseBrush", true);
                //audio_Clips.PlayAudioOne();
                audioSource.Play();
                Invoke("SpawnBrushOne", 2);
                //SpawnBrushOne();
                buttonsUnlocked = false;
                colorTwo = true;
                colorOne = false;
            }
            
        }
        if (colorTwo)//Blue + Red = Purple
        {
            if (paintButtonOne.blue & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.blue)
            {
                dispenserAnim.SetBool("DispenseBrush", true);
                //audio_Clips.PlayAudioOne();
                audioSource.Play();
                Invoke("SpawnBrushTwo", 2);
                //SpawnBrushTwo();
                buttonsUnlocked = false;
                colorThree = true;
                colorTwo = false;
            }
        }
        if (colorThree)// Yellow + Red = Orange
        {
            if (paintButtonOne.yellow & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.yellow)
            {
                dispenserAnim.SetBool("DispenseBrush", true);
                //audio_Clips.PlayAudioOne();
                audioSource.Play();
                Invoke("SpawnBrushThree", 2);
                //SpawnBrushThree();
                buttonsUnlocked = false;
                
                colorThree = false;
            }

        }
    }

    private void SpawnBrushOne()
    {
        Instantiate(brushOnePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        dispenserAnim.SetBool("DispenseBrush", false);
        //audio_Clips.PlayAudioOne();
        audioSource.Play();

        goalColor.GetComponent<Renderer>().material.color = purple;

    }
    private void SpawnBrushTwo()
    {
        Instantiate(brushTwoPrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        dispenserAnim.SetBool("DispenseBrush", false);
        //audio_Clips.PlayAudioOne();
        audioSource.Play();

        goalColor.GetComponent<Renderer>().material.color = orange;



    }
    private void SpawnBrushThree()
    {
        Instantiate(brushThreePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        dispenserAnim.SetBool("DispenseBrush", false);
        //audio_Clips.PlayAudioOne();
        audioSource.Play();



    }

}
