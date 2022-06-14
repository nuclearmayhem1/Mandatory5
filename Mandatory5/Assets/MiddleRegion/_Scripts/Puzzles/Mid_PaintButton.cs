using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PaintButton : MonoBehaviour
{
    Color[] colors = new Color[] { Color.white, Color.red, Color.magenta, Color.blue, Color.cyan, Color.yellow };
    public int currentColor;
    private bool inContactWithPlayer;
    private Mid_PaintDispenser paintDispenser;
    public bool yellow, blue, red;
    public bool dispenserActive;


    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0;
        this.GetComponent<Renderer>().material.color = colors[currentColor];

        paintDispenser = GameObject.Find("PaintDispenser").GetComponent<Mid_PaintDispenser>();
        dispenserActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dispenserActive)
        {
            if (inContactWithPlayer & paintDispenser.buttonsUnlocked)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentColor = (currentColor + 1) % colors.Length;
                    this.GetComponent<Renderer>().material.color = colors[currentColor];

                }
            }
        }

        
        

        if (currentColor == 1) 
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
            inContactWithPlayer = true;
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
