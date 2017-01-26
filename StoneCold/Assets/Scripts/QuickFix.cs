using UnityEngine;
using System.Collections;

public class QuickFix : MonoBehaviour 
{
	public bool disablemovement;
	public bool swimming;
	public bool climbing;
	public bool cutscene;
	public bool reading;

	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameManager.disableMovement = disablemovement;
		GameManager.isSwimming = swimming;
		GameManager.onCutscene = cutscene;
		GameManager.isReading = reading;
	
	}
}
