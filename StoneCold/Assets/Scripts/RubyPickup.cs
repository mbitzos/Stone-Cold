using UnityEngine;
using System.Collections;

public class RubyPickup : MonoBehaviour 
{
	public bool itemCollect=false;
	public float circleRadius=0.3f;
	//sprite of the object
	private SpriteRenderer kawaii;
	private Animator bubbleanim;
	public int GemID= 1;
	//pick up timer
	private bool timer;
	private float time= 0;
	public float timePickup;
	//wall 
	public GameObject wall;

	void Start () 
	{
		//getting components
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		kawaii = GetComponent<SpriteRenderer>();
		if (GameManager.chestOpen)
		{
			gameObject.GetComponent<Animator>().Play ("Opened");
			wall.GetComponent<Animator>().Play("Down");
		}

	}
	
	
	void Update () 
	{
		//adding to list
		itemCollect = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));
		if(itemCollect && GameManager.chestOpen ==false)
		{
			bubbleanim.SetBool("interest",true);
			if(Input.GetButton ("Fire1"))
			{
				Invoke ("turnOff" ,timePickup);
				GameManager.onCutscene=true;
				GameManager.disableMovement=true;
				GameManager.isReading=true;

				GameManager.chestOpen = true;
				timer=true;
				gameObject.GetComponent<Animator>().Play ("Open");
				GameManager.gems[GemID] =true;
				GameManager.items.Add (kawaii.sprite);
			}

		}
		else
		{
			bubbleanim.SetBool("interest",false);
		}
		if (timer)
		{
			time += Time.deltaTime ;
		}
		if(time >= timePickup)
		{
			wall.GetComponent<Animator>().SetBool("Open", true);
			time=0;
			timer=false;
			bubbleanim.Play("speechBubble_backpack");
		}
		
	}

	void turnOff ()
	{
		GameManager.onCutscene=false;
		GameManager.disableMovement=false; 
		GameManager.isReading=false;
		
	}
}
