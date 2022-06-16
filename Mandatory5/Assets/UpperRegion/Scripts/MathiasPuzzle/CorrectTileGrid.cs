using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectTileGrid : MonoBehaviour
{
	public static CorrectTileGrid instance;
	public bool correct = false;
	public Tiles[] scripts;
	public float timeRemaining = 10f;
	public bool timerIsRunning = false;
	public int loadingBar = 0;
	private void Awake()
	{
		instance = this;
	} 
	void Start()
    {
		gameObject.GetComponent<Rotating>().enabled = false;
		
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
		var randomNub = Random.Range(0, 12);
		scripts[randomNub].Activate();	
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var tiles in scripts)
            {
				tiles.lose();
			}	
        }
    }
	public void PuzzleStart()
    {
		timerIsRunning = true;
		timeRemaining = 10f;

		gameObject.GetComponent<Rotating>().enabled = true;
		
		foreach (var tilesScripts in scripts)
        {
			tilesScripts.enabled = true;
		}
		Tiles.tilesScript.Activate();
	}
}
