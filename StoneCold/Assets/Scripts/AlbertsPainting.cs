using UnityEngine;
using System.Collections;

public class AlbertsPainting : MonoBehaviour 
{
	//components needed
	public Transform player;
	private Animator bubbleanim;
	private Animator paintingAnim;
	public float radius = 0.3f;
	//timer for painting allow entrance
	private bool timer;
	public float timeLimit;
	private float waitTime =0.5f;
	void Start () 
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		paintingAnim = gameObject.GetComponent<Animator> ();
		if (GameManager.paintingOpen ==true)
		{
			paintingAnim.Play("AlbertsPainting");
		}
	}

	void Update () 
	{
		if(!GameManager.paintingOpen) 
		{
			//checking if player is near painting
			bool rip = Physics2D.OverlapCircle (transform.position,radius,1 << LayerMask.NameToLayer ("Player"));
			if(rip && player.position.y > -0.41f)
			{
			
				//speech bubble animation
				if(!GameManager.paintingOpen)
					bubbleanim.SetBool("interest",true);
				if(Input.GetButtonDown ("Fire1"))
				{
					timer=true;
					paintingAnim.Play ("AlbertsPaintingOpening");
				}
			}
			else
			{
				bubbleanim.SetBool("interest",false);
			}
			if (timer)
				waitTime -= Time.deltaTime; 
			if (waitTime < 0)
			{
				//setting the entrance avalaible 
				timer=false;
				waitTime = timeLimit;
				GameManager.paintingOpen =true;
				GetComponent<NextSceneWalk>().enabled =true;
			}
		}
	}
}
