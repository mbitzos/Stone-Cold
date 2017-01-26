using UnityEngine;
using System.Collections;

public class oneWayColliderStairs : MonoBehaviour 
{
	private Transform player;
	private GameObject player1;
	public bool allowCollider=false;
	void Start () 
	{
		player1 = GameObject.Find ("Character");
		player = player1.transform.FindChild ("groundCheck1");
	}
	
	void OnCollisionStay2D()
	{
		allowCollider = true;
		if(Input.GetAxis ("Vertical") < 0)
		{
			allowCollider =false;
			gameObject.collider2D.enabled=false;
		}	
	}
	void Update () 
	{
		//long process for the stairs on the first house

		if(player.transform.position.x < transform.position.x)
		{

			allowCollider=true; 

		}
		else if((player.transform.position.x > transform.position.x) && (player.transform.position.y < transform.position.y))
		{

			allowCollider=false; 
			
		}
		else if(player.transform.position.y < transform.position.y)
		{
		
			allowCollider=false;
		}

		if((player.transform.position.y> transform.position.y) && allowCollider )  
		{
			gameObject.collider2D.enabled=true;
		}
		else if (player.transform.position.y < transform.position.y)
		{

			gameObject.collider2D.enabled=false;
		}


	}


}
