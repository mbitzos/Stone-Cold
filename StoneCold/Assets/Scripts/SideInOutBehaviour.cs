using UnityEngine;
using System.Collections;

public class SideInOutBehaviour : MonoBehaviour 
{

	private bool timer=true;
	public float timeDuration;
	public float time;
	public bool isOn;
	private Animator anim;
	
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}
	
	void Update () 
	{
		if(timer)
		{
			time -= Time.deltaTime;
		}
		if(time<0)
		{
			timer=false;
			Activate();
			
		}
	}
	
	void Activate()
	{
		time = timeDuration; 
		if(isOn)
		{
			anim.SetBool ("Out",false);
			timer=true;
		}
		else
		{
			anim.SetBool ("Out",true);
			timer=true;
		}
		isOn = !isOn;
	}
}
