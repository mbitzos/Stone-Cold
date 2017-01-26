using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour 
{
	public Rigidbody2D character;
	public float gravity= 0.5f;
	


	void OnTriggerEnter2D() 
	{
		GameManager.isSwimming = true;
		GameManager.disableMovement = true;
		character.gravityScale = gravity;
	}

	void OnTriggerExit2D() 
	{
		GameManager.disableMovement = false;
		GameManager.isSwimming = false;
		character.gravityScale = 1;
	}
}
