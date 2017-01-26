using UnityEngine;
using System.Collections;

public class CutsceneFall : MonoBehaviour 
{
	public bool turnOn=false;
	public float timeLimit= 2f;
	public float spawnlocation= 0;

	void Start () 
	{
		turnOn = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(turnOn &&GameManager.spawnLocation==spawnlocation)
		{
			Invoke ("turnOff" ,timeLimit);
			GameManager.onCutscene=true;
			GameManager.disableMovement=true; 
		}

	}
	void turnOff ()
	{
		turnOn = false;
		GameManager.onCutscene=false;
		GameManager.disableMovement=false; 

	}
}
