using UnityEngine;
using System.Collections;

public class LimitCF : MonoBehaviour 
{

	public Transform[] cameraPoints;
	public Transform followObject;
	private Vector3 intialOffSet;
	private Vector3 intialOffSet2;
	public Transform indication;
	public float smooth=5f;

	void Start () 
	{
		intialOffSet =  cameraPoints[0].position; 
		intialOffSet2 = cameraPoints [1].position;

	}
	
	
	void Update () 
	{

		//WORK ON THIS. MAKE A UNIVERAL FORM SO THAT YOU CAN REUSE IT
		//PAN X ON ONE SET, PAN X ON ANOTHER SET, TO DIFFERENT HEIGHTS.
		if (followObject.position.x > cameraPoints [0].position.x && followObject.position.x < cameraPoints [1].position.x &&followObject.position.y < cameraPoints [2].position.y)
		{
			transform.position =intialOffSet + (new Vector3(followObject.position.x -cameraPoints[0].position.x,0,0));
		}

		if (followObject.position.y > cameraPoints [2].position.y && followObject.position.y < indication.position.y) 
		{
			transform.position =intialOffSet2 + (new Vector3(0,followObject.position.y -cameraPoints[0].position.y,0));
		}

		if (followObject.position.y > indication.position.y) 
		{
			if(followObject.position.x > cameraPoints[4].position.x)
			{
				//transform.position = cameraPoints[4].position;
				transform.position= Vector3.Lerp(transform.position, cameraPoints[4].position,Time.deltaTime* smooth);
			}
			else if(followObject.position.x < cameraPoints[5].position.x)
			{
				//transform.position = cameraPoints[5].position;
				transform.position= Vector3.Lerp(transform.position, cameraPoints[5].position,Time.deltaTime *smooth);
			}
			else if(followObject.position.x > cameraPoints[5].position.x && followObject.position.x < cameraPoints[4].position.x)
			{
				transform.position= Vector3.Lerp(transform.position, cameraPoints[3].position,Time.deltaTime *smooth);
			}

		}

	}
}
