using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public static Tiles tilesScript;


    public Material Green, Yellow, Red, Black;

    private Renderer color;

    public bool isActive = false;

    private void Awake()
    {
        tilesScript = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        color = transform.GetComponent<Renderer>();
        
    }
    public void  Activate()
    {
        if (color == null)
        {
            color = transform.GetComponent<Renderer>();
        }
        isActive = true;
        color.material = Green;
    }

    // Update is called once per frame
    void Update()
    {
        Win();
        if (isActive == true)
        {
            if (CorrectTileGrid.instance.timeRemaining == 0)
            {
                color.material = Black;
                isActive = false;
                print("u nob");
            }
            else if (CorrectTileGrid.instance.timeRemaining < 3)
            {
                color.material = Red;
            }
            else if (CorrectTileGrid.instance.timeRemaining < 5)
            {
                color.material = Yellow;
            }
        }
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive == true)
        {
			if (color.material != Black)
			{
                CorrectTileGrid.instance.loadingBar++;
                CorrectTileGrid.instance.timeRemaining = 10f;
                CorrectTileGrid.instance.timerIsRunning = true;
                color.material = Black;
                isActive = false;
                print(CorrectTileGrid.instance.loadingBar);
                CorrectTileGrid.instance.Nexttile();
            }
        }
    }
    public void lose()
    {
        CorrectTileGrid.instance.timerIsRunning = false;
        isActive = false;
        color.material = Black;
        Rotating.rotation.rotationSpeed = 0f;
        CorrectTileGrid.instance.loadingBar = 0;  
    }

    public void Win()
    {
        if (CorrectTileGrid.instance.loadingBar == 12)
        {
            CorrectTileGrid.instance.timerIsRunning = false;
            isActive = false;
            color.material = Green;
            Rotating.rotation.rotationSpeed = 0f;
            
            print("YOuWooon");
        }
    }
}
