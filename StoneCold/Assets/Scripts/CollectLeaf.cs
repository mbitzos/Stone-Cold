using UnityEngine;
using System.Collections;

public class CollectLeaf: MonoBehaviour 
{
	public bool itemCollect=false;
	public float circleRadius=0.3f;
	//sprite of the leaf
	private SpriteRenderer kawaii;
	private Animator bubbleanim;
	public int leafID;
	//pick up timer
	private bool timer;
	private float time= 0;
	private bool collected=false;

	void Start () 
	{
		//getting components
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		kawaii = GetComponent<SpriteRenderer>();
		if (GameManager.metalLeaves [leafID] == true)
			gameObject.SetActive (false);
	}
	

	void Update () 
	{
		//adding to list
		itemCollect = Physics2D.OverlapCircle (transform.position,circleRadius,1 << LayerMask.NameToLayer ("Player"));
		if(itemCollect && collected==false)
		{
			collected=true;
			gameObject.GetComponent<Animator>().Play ("Pickup");
			bubbleanim.Play("speechBubble_backpack");
			GameManager.metalLeaves[leafID] =true;
			GameManager.items.Add (kawaii.sprite);
			timer= true;
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
