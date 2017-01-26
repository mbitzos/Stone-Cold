using UnityEngine;
using System.Collections;

public class GemStones : MonoBehaviour
{

	public bool itemCollect=false;
	public float circleRadius=0.3f;
	//sprite of the object
	private SpriteRenderer kawaii;
	private Animator bubbleanim;
	public int GemID;
	//pick up timer
	private bool timer;
	private float time= 0;
	public float timePickup;
	
	void Start () 
	{
		//getting components
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		kawaii = GetComponent<SpriteRenderer>();
		if (GameManager.gems[GemID] == true)
			gameObject.SetActive (false);
	}
	
	
	void Update () 
	{
		//adding to list
		itemCollect = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));
		if(itemCollect)
		{
			timer=true;
			gameObject.GetComponent<Animator>().Play ("Pickup");
			GameManager.gems[GemID] =true;
			GameManager.items.Add (kawaii.sprite);
		}
		if (timer)
		{
			time += Time.deltaTime ;
		}
		if(time >= timePickup)
		{
			time=0;
			timer=false;
			bubbleanim.Play("speechBubble_backpack");
			gameObject.SetActive (false);
		}
		
	}
}
