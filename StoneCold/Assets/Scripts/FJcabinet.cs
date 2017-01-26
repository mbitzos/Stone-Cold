using UnityEngine;
using System.Collections;

public class FJcabinet : MonoBehaviour 
{
	public GameObject spawn2;
	private bool timer;
	private float time =2f;

	void Start () 
	{
		if (GameManager.secretwall && GameManager.alreadyEntered ==false)
		{
			gameObject.GetComponent<Animator>().Play ("move");
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
			GameManager.onCutscene= true;
			GameManager.disableMovement= true; 
			timer=true;
		}
		else if(GameManager.secretwall == false)
		{
			gameObject.GetComponent<Animator>().Play ("Idle");
			spawn2.SetActive (false);

		}
		else if(GameManager.secretwall ==true && GameManager.alreadyEntered)
		{
			gameObject.GetComponent<Animator>().Play ("moved");
		}


	}
	

	void Update () 
	{
		if(timer)
		{
			time -=Time.deltaTime;
		}
		if(time < 0)
		{
			timer= false;
			time= 2f;
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
			GameManager.onCutscene= false;
			GameManager.disableMovement= false;
			GameManager.alreadyEntered =true;

		}

	}
}
