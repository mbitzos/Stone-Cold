using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public Transform charTran;
	public Rigidbody2D character;
	public bool climbingAllow=false;
	private bool climbing = false;
	private float speed= 2f;
	public float move;
	private Vector3 transformx;

	private bool timer;
	public float timelim= 0;

	void Start () 
	{
		transformx = transform.position;
	}

	void Update () 
	{

		if(GameManager.onCutscene ==false && GameManager.isReading==false )
		{

			if(Input.GetButtonDown ("Jump") && climbing)
			{
				climbing=false;
				character.gravityScale = 1;
				move= 0;
				timelim=0.4f;
				timer=true;
				climbing=false;
				GameManager.disableMovement=false;
				GameManager.isClimbing=false;
			}
			if (climbingAllow && (Input.GetAxis ("Vertical") > 0) && timelim <= 0)
			{
				GameManager.disableMovement=true;
				GameManager.isClimbing=true;
				climbing=true;
			}

			if(climbing)
			{
				move = Input.GetAxis ("Vertical");
				timer=false;
				timelim =0.4f; 
				charTran.position = new Vector2(Mathf.Lerp(charTran.position.x,transformx.x,Time.deltaTime *5f),charTran.position.y); 
				character.velocity = new Vector2(0,move * speed);
				character.gravityScale = 0;
			}
			else
			{
				move=0;
			
			}

			if(timer)
			{

				timelim -= Time.deltaTime;

			}
		}

	}

	void OnTriggerEnter2D()
	{
		climbingAllow = true;

	}	

	void OnTriggerExit2D()
	{
		timelim = 0;
		climbing = false;
		climbingAllow = false;
		character.gravityScale = 1;
		GameManager.disableMovement=false;
		GameManager.isClimbing=false;

	}

}
