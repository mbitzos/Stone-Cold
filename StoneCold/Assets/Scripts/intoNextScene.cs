using UnityEngine;
using System.Collections;

public class intoNextScene : MonoBehaviour 
{
	public bool allowNext=false;
	public float radius =0.3f;
	public int spawnNumber;
	public int levelNumber;
	//up,down,left,right
	public string behaviourDirection;
	//needed transform
	public Transform player;
	private Vector2 transformF;
	
	void Start()
	{
		transformF = transform.position;

	}

	void Update()
	{
		allowNext = Physics2D.OverlapCircle (transform.position,radius,1 << LayerMask.NameToLayer ("Player"));
		if(allowNext) 
		{
			//cases for the direction
			switch (behaviourDirection)
			{
			case "right":
			{
				if(player.position.x >= transformF.x)
					nextLevel ();
				break;
			}
			case "left":
			{
				if(player.position.x >= transformF.x)
					nextLevel ();
				break;
			}
			case "down":
			{
				if(player.position.y <= transformF.y)
					nextLevel ();
				break;
			}
			case "up":
			{
				if(player.position.y >= transformF.y)
					nextLevel ();
				break;
			}
			}
			
		}
		
	}
	
	void nextLevel()
	{
		Application.LoadLevel(levelNumber);
		GameManager.spawnLocation = spawnNumber;
	}
}
