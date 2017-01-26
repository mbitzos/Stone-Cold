using UnityEngine;
using System.Collections;

public class NextSceneWalk : MonoBehaviour 
{
	public bool allowNext=false;
	public float radius =0.3f;
	public int spawnNumber;
	public int levelNumber;
	//up,down,left,right
	public string behaviourDirection;
	

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
					if(Input.GetAxis ("Horizontal") > 0)
						nextLevel ();
				break;
				}
				case "left":
				{
					if(Input.GetAxis ("Horizontal") < 0)
						nextLevel ();
				break;
				}
				case "down":
				{
					if(Input.GetAxis ("Vertical") < 0)
						nextLevel ();
				break;
				}
				case "up":
				{
					if(Input.GetAxis ("Vertical") > 0)
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
