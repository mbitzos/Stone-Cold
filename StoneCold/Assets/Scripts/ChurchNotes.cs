using UnityEngine;
using System.Collections;

public class ChurchNotes : MonoBehaviour 
{
	
	//timers
	private bool startTimer = false;
	public float waitTime =1f;
	//overlapCircle
	private bool itemRead;
	private bool itemRead2;

	private string activationButton = "Fire1";

	//game objects needed
	public GameObject note;
	public Sprite notes;
	public Transform otherNote;
	private Animator bubbleanim;
	public float circleRadius=0.3f;
	
	void Start()
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
	}
	
	void Update () 
	{
		itemRead2 = Physics2D.OverlapCircle (otherNote.position, circleRadius, 1 << LayerMask.NameToLayer ("Player"));
		//reading zone
		itemRead = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));

		if(itemRead)
		{
			bubbleanim.SetBool ("journal",true);
		}
		else if(itemRead2)
		{
			bubbleanim.SetBool ("journal",true);

		}
		else
		{
			bubbleanim.SetBool ("journal",false);
		}
		//disable movement start the timer
		//timer is so that they dont instantly change the page and exit at the start
		if(itemRead && Input.GetButtonDown(activationButton))
		{
			GameManager.disableMovement = true;
			GameManager.isReading =true;
			startTimer =true;
			note.GetComponent<SpriteRenderer>().sprite= notes;
			note.renderer.enabled =true;
			
		}

		//timer logic
		if(startTimer == true)
		{
			waitTime -= Time.deltaTime;
		}
		//exitting
		if ((waitTime < 0) && Input.GetButtonDown(activationButton))
		{
			GameManager.disableMovement = false;
			GameManager.isReading =false;
			startTimer=false;
			waitTime=1f;
			note.renderer.enabled =false;
		}
	}
}
