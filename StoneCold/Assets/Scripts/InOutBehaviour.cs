using UnityEngine;
using System.Collections;

public class InOutBehaviour : MonoBehaviour {

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
			gameObject.collider2D.enabled = false;
			anim.SetBool ("Out",false);
			timer=true;
		}
		else
		{
			gameObject.collider2D.enabled = true;
			anim.SetBool ("Out",true);
			timer=true;
		}
		isOn = !isOn;
	}
}
