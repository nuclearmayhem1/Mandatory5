using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    //private bool isActive = true;

    public Material Green, Yellow, Red, Black;

    private Renderer color;



    // Start is called before the first frame update
    void Start()
    {
        color = transform.GetComponent<Renderer>();
        color.material = Green;
    }

    // Update is called once per frame
    void Update()
    {

        if (CorrectTileGrid.instance.timeRemaining < 5)
        {
            color.material = Yellow;
        }
        if (CorrectTileGrid.instance.timeRemaining < 3)
        {
            color.material = Red;
        }
        if (CorrectTileGrid.instance.timeRemaining == 0)
        {
            color.material = Black;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
			if (color.material != Black)
			{
                CorrectTileGrid.instance.timeRemaining = 10f;
                CorrectTileGrid.instance.timerIsRunning = true;
                print("TimerReset");
                color.material = Black;
                CorrectTileGrid.instance.loadingBar++;
                CorrectTileGrid.instance.Nexttile();
                this.enabled = false;
                //isActive = false;
            }
        }
    }






}
