using UnityEngine;
using System.Collections;

public class HcameraFollow : MonoBehaviour 
{
	public Transform[] cameraPoints;
	public Transform followObject;
	private Vector3 intialOffSet;
	private Transform transformx;
	public bool allow;
	public string direction;
	public float diff1;
	public float diff2;

	void Start () 
	{
		diff1 = followObject.position.x - cameraPoints [0].position.x;
		diff2 = followObject.position.x - cameraPoints [1].position.x;
		if( Mathf.Abs(diff1) <  Mathf.Abs (diff2))
		{
			//direction= "right";
			intialOffSet.x =  cameraPoints[0].position.x; 

		}
		else
		{
			//direction = "left";
			intialOffSet.x =  cameraPoints[1].position.x;
			transform.position = cameraPoints[1].position;
		}
	}
	

	void Update () 
	{
		switch (direction)
		{
			case "left":
			{
				if (followObject.position.x < cameraPoints [0].position.x && followObject.position.x > cameraPoints [1].position.x) 
				{
					allow=true;
					transform.position = (new Vector3(followObject.position.x,0,-0.4f)); 
				}
				else
				{
					allow= false;
				}
			break;
			}
			case "right" :
			{
				print ("right");
				if (followObject.position.x > cameraPoints [0].position.x && followObject.position.x < cameraPoints [1].position.x) 
				{
					allow=true;
					transform.position = (new Vector3(followObject.position.x,0,-0.4f)); 
				}
				else
				{
					allow= false;
				}
			break;
			}
		}

	}
}
