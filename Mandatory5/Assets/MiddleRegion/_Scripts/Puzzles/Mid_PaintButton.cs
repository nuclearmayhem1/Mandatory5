using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PaintButton : MonoBehaviour
{
    Color[] colors = new Color[] { Color.white, Color.red, Color.magenta, Color.blue, Color.cyan, Color.yellow };   //Creates an array of 6 specific colors.
    public int currentColor;
    private bool inContactWithPlayer;
    private Mid_PaintDispenser paintDispenser;
    public bool yellow, blue, red;
    public bool dispenserActive;
    public GameObject touchPaint;


    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0;                                                           
        this.GetComponent<Renderer>().material.color = colors[currentColor];        

        paintDispenser = GameObject.Find("PaintDispenser").GetComponent<Mid_PaintDispenser>();
        //dispenserActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dispenserActive)
        {

            touchPaint.SetActive(false);
            
            if (inContactWithPlayer & paintDispenser.buttonsUnlocked)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentColor = (currentColor + 1) % colors.Length;              //Increases the currentColor int by 1 each time.
                                                                                    //Restarts when it has reached the end of the array.
                    this.GetComponent<Renderer>().material.color = colors[currentColor];        //Changes the color to be the current int color in the array.

                }
            }
        }
        else
        {
            touchPaint.SetActive(true);
        }

        
        

        if (currentColor == 1)                  //When the currentColor int = x, then the different color bools are turned true.
        {
            red = true;
        }
        if (currentColor == 3)
        {
            blue = true;
        }
        if (currentColor == 5)
        {
            yellow = true;
        }
        if (currentColor == 0 || currentColor == 2 || currentColor == 4)
        {
            red = false;
            blue = false;
            yellow = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = true;                     //In order to be able to press the button only when the player is close enough.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inContactWithPlayer = false; 
        }
    }
}
