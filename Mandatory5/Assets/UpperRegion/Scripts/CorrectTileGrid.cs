using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectTileGrid : MonoBehaviour
{
	public static CorrectTileGrid instance;

    public bool correct = false;
    


	public int loadingBar;


	public Tiles[] scripts;

	public float timeRemaining = 10f;
	public bool timerIsRunning = false;


	private void Awake()
	{
		instance = this;
	} 
	
	
	void Start()
    {
		

		timerIsRunning = true;
		Nexttile();
		

    }

    // Update is called once per frame
    void Update()
    {
		Timer();
		
    }


	private void Timer()
	{
		if (timerIsRunning)
		{
			if (timeRemaining > 0)
			{
				timeRemaining -= Time.deltaTime;
			}
			else
			{
				print("TimerDone");
				timeRemaining = 0f;
				
				timerIsRunning = false;	
			}
		
		}
	}
	public void Nexttile()
	{
		scripts[Random.Range(0, 12)].enabled = true;
	}
}
