using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform followObject;
	private Vector3 intialOffSet;
	public bool withOffset= true;

	void Start () 
	{
		//makes the camera not snap to charcter position
		if(withOffset) 
			intialOffSet = transform.position - followObject.position; 
	}

	void Update () 
	{
		if (LerpCameraSize.on == false)
		{
			if(withOffset)
			{
				transform.position = intialOffSet + followObject.position;
			}
			else
			{
				transform.position= (new Vector3(0,0,transform.position.z))+ followObject.position; 
			}
		}
	}
}
