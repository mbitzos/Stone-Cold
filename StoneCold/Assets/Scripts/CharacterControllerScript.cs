using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CharacterControllerScript : MonoBehaviour 
{
	//running
	public float move =0f;
	public float maxSpeed = 2f;
	private	bool facingRight = true;
	Animator anim;
	//jumping
	private string jumpButton = "Jump";
	public bool grounded =false;
	public Transform[] groundChecks;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 200f;

	//spawning
	public Transform[] spawnLocation;

	//backpack
	private string inventoryButton= "Fire2";
	private GameObject backpackZoom;
	private Animator backpackAnim;
	private float waitTime =1f;
	private bool startTimer=false;

	//movingplatform
	public Transform currentPlatform =null;
	private Vector3 previousPlatform= Vector3.zero;
	private Vector3 platformDelta = Vector3.zero;
	public float platformCheckDistance = 0.25f;
	public float noAccelerationCheck = 50f;


	void Start () 
	{
		//getting components
		anim = GetComponent<Animator>();
	    transform.position = spawnLocation[GameManager.spawnLocation].position;
		//backpackZoom = GameObject.Find ("backpackZoom");
		//backpackAnim = backpackZoom.GetComponent<Animator> ();

	}
	void Update()
	{

		if(GameManager.disableMovement ==false)
		{
			//jumping logic
			grounded = false;
			foreach(Transform groundCheck in groundChecks)
			{
				grounded |= Physics2D.Linecast (transform.position, groundCheck.position, whatIsGround);
			}
			anim.SetBool("Ground",grounded);
			if (grounded && Input.GetButtonDown (jumpButton)) 
			{
				anim.SetBool ("Ground", false);
				rigidbody2D.AddForce (new Vector2 (0, jumpForce));

			}


			//moving platform logic
			List <Transform> platforms = new List<Transform>(); 
			bool onSamePlatform = false;
			if (onSamePlatform)
			{
				currentPlatform = null;
			}
			else
			{
				RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, platformCheckDistance, whatIsGround);
				if(hit.transform != null)
				{
					platforms.Add (hit.transform);
					if( currentPlatform == hit.transform)
					{
						onSamePlatform= true;
					}
					
				}
				if( !onSamePlatform)
				{
					foreach( Transform platform in platforms)
					{
						currentPlatform = platform; 
						previousPlatform = currentPlatform.position;
					}
				}
			}

			if(!grounded)
			{
				RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -Vector3.up, noAccelerationCheck, whatIsGround);
				if(hit2.transform != currentPlatform)
				{
					currentPlatform = null;
				}
			}
		}
		//inventory logic
		else if(GameManager.onCutscene ==false && GameManager.isReading ==false)
		{

			if (grounded && Input.GetButtonDown(inventoryButton))
			{ 
				GameManager.disableMovement =true;
				backpackAnim.SetBool("start",true);
				startTimer=true;
				GameManager.inventory =true;
				
			}
			if(startTimer==true)
			{
				waitTime -= Time.deltaTime;
			}
			if((waitTime < 0) && Input.GetButtonDown(inventoryButton))
			{
				GameManager.disableMovement=false;
				backpackAnim.SetBool ("start",false);
				startTimer=false;
				waitTime= 1f;
				GameManager.inventory =false;
			}
		}

		//setting game mechanics
		if(GameManager.disableMovement)
		{
			anim.SetBool("Ground",true);
			move=0;
			if(GameManager.isReading)
				rigidbody2D.velocity= (new Vector2 (0,0));
		}
		if(GameManager.isSwimming)
		{
			Swimming();
		}
		if(GameManager.isClimbing)
		{
			anim.SetBool("Ground",true);
			anim.SetFloat("Speed", 0);
		}
		if(GameManager.onCutscene)
		{
			//stuff specific for each cutscene
		}
	
	}

	void FixedUpdate () 
	{
		//moving logic
		anim.SetFloat("Speed", Mathf.Abs(move));
		if(GameManager.disableMovement ==false)
		{
		 	move= Input.GetAxis ("Horizontal"); 
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

			if (move > 0 &&!facingRight) 
			{
				Flip ();
			}
			else if(move < 0 && facingRight)
			{
				Flip();
			}
		}
	}

	void LateUpdate()
	{
		//late calculating
		if(currentPlatform != null)
		{
			platformDelta = currentPlatform.position - previousPlatform;
			previousPlatform = currentPlatform.position;
		}
		if (currentPlatform != null)
		{
			//moving with the platform
			transform.position += platformDelta;
		}
	}

	void Flip()
	{
		//flipping logic
		facingRight =!facingRight; 
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	

	void Swimming()
	{
		move= Input.GetAxis ("Horizontal"); 
		rigidbody2D.velocity = new Vector2 ((move * maxSpeed)/2, rigidbody2D.velocity.y);
			
		if (move > 0 &&!facingRight) 
		{
			Flip ();
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}
		anim.SetFloat("Speed", Mathf.Abs(move));

		if (Input.GetButton(jumpButton)) 
		{
			rigidbody2D.AddForce (new Vector2 (0, 10f));
			
		}
	}




}
	
