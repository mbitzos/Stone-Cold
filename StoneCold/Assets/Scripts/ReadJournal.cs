using UnityEngine;
using System.Collections;

public class ReadJournal : MonoBehaviour 
{
	//number of pages to read
	public int Pages;
	//timers
	private bool startTimer = false;
	public float waitTime =1f;
	//overlap circle bool
	private bool itemRead;

	private string activationButton = "Fire1";
	//images for the journal pages and selector
	public Sprite[] journalPages;
	public Sprite[] pageNumber;
	//game objects needed
	private GameObject journal;
	private GameObject pageSelector;
	
	private Animator bubbleanim;
	public float circleRadius=0.3f;
	private bool reading =false;
	//the page number you are on
	private int onPageNumber=1;

	void Start()
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		journal = GameObject.Find ("zoomJournal");
		pageSelector = GameObject.Find ("journalPageSelector");
	}
	
	void Update () 
	{
		//reading zone
		itemRead = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));
		if(itemRead)
		{
			bubbleanim.SetBool ("journal",true);
		}
		else 
		{
			bubbleanim.SetBool ("journal",false);
		}
		//disable movement start the timer
		//timer is so that they dont instantly change the page and exit at the start
		if(itemRead && Input.GetButtonDown(activationButton) && GameManager.inventory ==false)
		{
			onPageNumber = 1;
			reading=true;
			GameManager.disableMovement = true;
			GameManager.isReading =true;
			startTimer =true;
			journal.GetComponent<SpriteRenderer>().sprite = journalPages[0]; 
			journal.renderer.enabled =true;
			pageSelector.renderer.enabled =true;
			pageSelector.GetComponent<SpriteRenderer>().sprite = pageNumber[0];

		}
		if(reading && waitTime < -0.1)
		{
			if(Pages > 1)
			{
				if(Input.GetAxis("Horizontal") >0 && onPageNumber < Pages)
				{
				
					//goes to next page
					waitTime =0.2f;
					startTimer=true;
					onPageNumber += 1;
					journal.GetComponent<SpriteRenderer>().sprite = journalPages[onPageNumber-1]; 
					pageSelector.GetComponent<SpriteRenderer>().sprite = pageNumber[onPageNumber -1];

				}
				else if(Input.GetAxis("Horizontal") <0 && onPageNumber > 1)
				{
					//goes back a page
					waitTime =0.2f;
					startTimer=true;
					onPageNumber-= 1; 
					journal.GetComponent<SpriteRenderer>().sprite = journalPages[onPageNumber -1]; 
					pageSelector.GetComponent<SpriteRenderer>().sprite = pageNumber[onPageNumber-1];
				}
			}
		}
		//timer logic
		if(startTimer == true)
		{
			waitTime -= Time.deltaTime;
		}
		//exitting
		if ((waitTime < 0) && Input.GetButtonDown(activationButton))
		{
			reading =false;
			GameManager.disableMovement = false;
			GameManager.isReading =false;
			startTimer=false;
			waitTime=1f;
			journal.renderer.enabled =false;
			pageSelector.renderer.enabled =false;
		}
	}
}
