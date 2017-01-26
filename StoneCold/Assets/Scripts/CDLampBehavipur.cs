using UnityEngine;
using System.Collections;

public class CDLampBehavipur : MonoBehaviour 
{
	public float maxIntensity = 0.96f;
	public float deltaPosition;
	private float intialOffSet;

	private Light lamp;
	private bool LightRadius=false;

	private GameObject character;

	private float lerpSmooth= 5f;

	void Start () 
	{
		character = GameObject.Find ("Character");
		lamp = gameObject.GetComponent<Light> ();
	}

	void Update () 
	{
		if(LightRadius)
		{
			deltaPosition = Mathf.Sqrt (Mathf.Pow(transform.position.x - character.transform.position.x,2f)+Mathf.Pow(transform.position.y - character.transform.position.y,2f));
			lamp.intensity = 0.3f/(Mathf.Abs(deltaPosition));
			if(lamp.intensity >= maxIntensity)
			{
				lamp.intensity = maxIntensity;
			}
		}
		else
		{
			lamp.intensity = Mathf.Lerp (lamp.intensity, 0, Time.deltaTime * lerpSmooth);
		}
	}

	void OnTriggerEnter2D()
	{

		LightRadius = true;
	}

	void OnTriggerExit2D()
	{
		LightRadius = false;
	}
}
