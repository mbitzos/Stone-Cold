using UnityEngine;
using System.Collections;

public class ChurchLever : MonoBehaviour 
{

	public float circleRadius=0.3f;
	public bool leverZone;
	private Animator bubbleanim;
	public GameObject ChurchOpening;

	
	void Start () 
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> (); 
		if(GameManager.leverStatus == true)
		{
			gameObject.GetComponent<Animator>().Play ("ChurchLeverOn");
			ChurchOpening.renderer.enabled =true;
			ChurchOpening.collider2D.enabled =false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.leverStatus ==false)
		{
			leverZone = Physics2D.OverlapCircle(transform.position,circleRadius,1<< LayerMask.NameToLayer("Player"));
			if(leverZone)
			{
				bubbleanim.SetBool("interest",true);
				if(Input.GetButtonDown ("Fire1"))
				{
					ChurchOpening.collider2D.enabled =false;
					ChurchOpening.renderer.enabled=true;
					bubbleanim.SetBool("interest",false);
					GameManager.leverStatus = true; 
					gameObject.GetComponent<Animator>().SetBool ("Status", GameManager.leverStatus);
				}

			}
			else
			{
				bubbleanim.SetBool("interest",false);
			}
		}

	}
}
