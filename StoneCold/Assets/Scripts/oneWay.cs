using UnityEngine;
using System.Collections;

public class oneWay : MonoBehaviour 
{
	private GameObject player1;
	public bool allowCollider=true;
	private Transform character;
	void Start () 
	{
		player1 = GameObject.Find ("Character");
		character = player1.transform.FindChild ("groundCheck1");
	}

	void Update() 
	{
		//if character is above the platform, activate it, else disable
		if((character.transform.position.y > transform.position.y) && allowCollider )
		{
			gameObject.collider2D.enabled=true;
		}
		else if((character.transform.position.y < transform.position.y))
		{
			allowCollider=true;
			gameObject.collider2D.enabled=false;
		}

	}
	void OnCollisionStay2D()
	{
		//if theu are on the collider, it must stay on
		if(Input.GetAxis ("Vertical") < 0)
		{
			allowCollider =false;
			gameObject.collider2D.enabled=false;
		}	
	}



	                     
}
