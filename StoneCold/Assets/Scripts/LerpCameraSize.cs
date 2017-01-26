using UnityEngine;
using System.Collections;

public class LerpCameraSize : MonoBehaviour 
{
	public Transform lerpTransform;
	public float cameraSize;
	public float cameraSize2;
	public Camera lerpCamera;
	public Transform character;
	
	public static bool on=false;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(on)
		{
			lerpCamera.orthographicSize   = Mathf.Lerp (lerpCamera.orthographicSize, cameraSize, Time.deltaTime * 5f);
			lerpCamera.transform.position = Vector3.Lerp (lerpCamera.transform.position, lerpTransform.position,Time.deltaTime *  5f);
		}
		else
		{
			lerpCamera.orthographicSize   = Mathf.Lerp (lerpCamera.orthographicSize, cameraSize2,Time.deltaTime *  5f);
			lerpCamera.transform.position = Vector3.Lerp (lerpTransform.position,character.position,Time.deltaTime *  5f);
		}
	}

	void OnTriggerEnter2D()
	{
		on = true;
	}

	void OnTriggerExit2D()
	{
		on = false;
	}
}
