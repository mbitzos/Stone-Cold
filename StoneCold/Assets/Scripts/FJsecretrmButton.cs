using UnityEngine;
using System.Collections;

public class FJsecretrmButton : MonoBehaviour 
{

	public GameObject wallanim;
	private bool btnStatus;
	public float radiusBtn= 0.25f;
	public GameObject spawn2;

	void Start () 
	{
		if(GameManager.secretwall)
		{
			gameObject.SetActive (false);
			spawn2.SetActive (true);
			wallanim.SetActive (false);
		}
		else
		{
			gameObject.SetActive (true);
			spawn2.SetActive (false);
		}
	}

	void Update () 
	{
		btnStatus = Physics2D.OverlapCircle(transform.position,radiusBtn,1<< LayerMask.NameToLayer("Player"));
		if(btnStatus && Input.GetButton ("Fire1"))
		{
			gameObject.SetActive (false);
			Invoke ("activateSpawn", 1f);
			wallanim.GetComponent<Animator> ().SetBool ("on?",btnStatus);
			GameManager.secretwall =true;
		}

	}

	void activateSpawn()
	{
		spawn2.SetActive (true);
	}
}
