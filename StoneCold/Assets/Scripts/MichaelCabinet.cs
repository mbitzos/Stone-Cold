using UnityEngine;
using System.Collections;

public class MichaelCabinet : MonoBehaviour 
{
	public float circleRadius=0.5f;
	//items in cabinet
	public GameObject[] items; 
	public bool cabinetOpenZone;
	private Animator bubbleanim;
	public GameObject cabinet;
	void Start () 
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> (); 
		//if it has been opened, stayed open and not active
		if(GameManager.cabinetOpen ==true)
		{
			gameObject.SetActive (false);
			items[0].SetActive (true);
			cabinet.GetComponent<Animator>().Play("cabinetOpened"); 
		}
		else
		{
			items[0].SetActive (false);
			items[1].SetActive (false); 
		}
	}
	

	void Update () 
	{
		//opening zone
		cabinetOpenZone = Physics2D.OverlapCircle (transform.position, circleRadius,1<<LayerMask.NameToLayer("Player"));
		if(cabinetOpenZone)
		{
			if(!GameManager.cabinetOpen)
			{
				bubbleanim.SetBool("interest",true);
			}

			if(Input.GetButtonDown("Fire1"))
			{
				//disabling cabinet
				bubbleanim.SetBool("interest",false);
				GameManager.cabinetOpen=true;
				cabinet.GetComponent<Animator>().Play("cabinetOpen"); 
				items[0].SetActive (true);
				items[1].SetActive (true);
				/*if(GameManager.key[1]== true)
				{
					items[1].SetActive (true);
				}*/
				gameObject.SetActive (true);
			}
		}
	}


}
