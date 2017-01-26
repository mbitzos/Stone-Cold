using UnityEngine;
using System.Collections;

public class CollectKey : MonoBehaviour 
{
	public bool itemCollect=false;
	public float circleRadius=0.3f;
	//sprite of the object
	private SpriteRenderer kawaii;
	private Animator bubbleanim;
	public int keyID;
	//pick up timer
	private bool timer;
	private float time= 0;

	void Start () 
	{
		//getting components
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		kawaii = GetComponent<SpriteRenderer>();
		if (GameManager.key [keyID] == true)
			gameObject.SetActive (false);
	}
	
	
	void Update () 
	{
		//adding to list
		itemCollect = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));
		if(itemCollect)
		{
			timer=true;
			bubbleanim.Play("speechBubble_backpack");
			gameObject.GetComponent<Animator>().Play ("Pickup");
			GameManager.key[keyID] =true;
			GameManager.items.Add (kawaii.sprite);
		}
		if (timer)
		{
			time += Time.deltaTime ;
		}
		if(time >= 0.6f)
		{
			time=0;
			timer=false;
			gameObject.SetActive (false);
		}

	}
}
