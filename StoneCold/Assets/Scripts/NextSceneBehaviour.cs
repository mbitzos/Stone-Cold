using UnityEngine;
using System.Collections;

public class NextSceneBehaviour : MonoBehaviour 
{

	public bool allowNext=false;
	public float radius;
	private string activationButton= "Fire1";
	//level variables
	public int spawnNumber;
	public int levelNumber;
	//key variables
	public bool needKey=false;
	public int keyID;
	public GameObject locks;
	private Animator lockanim;
	//waiting time
	public float time=1f;
	private bool starttimer=false;
	private Animator bubbleanim;
	private bool alreadyOpen;

	void Start()
	{
		bubbleanim = GameObject.Find ("speechBubble").GetComponent<Animator> ();
		//if unlocked, set unlocked
		if(needKey)
		{
			lockanim= locks.GetComponent<Animator>();
			if(GameManager.locks[keyID] == true)
			{
				alreadyOpen = true;
				locks.SetActive(false);
			}
		}


	}

	void Update()
	{
		//key open zone
		allowNext = Physics2D.OverlapCircle (transform.position,radius,1 << LayerMask.NameToLayer ("Player"));
		if (needKey ==false)
		{
			if(allowNext && Input.GetButtonDown (activationButton))
			{
				Application.LoadLevel(levelNumber);
				GameManager.spawnLocation = spawnNumber;
			}
		}
		else
		{
			if(allowNext && Input.GetButtonDown (activationButton) && GameManager.key[keyID] ==true)
			{
				if(alreadyOpen)
				{
					Application.LoadLevel(levelNumber);
					GameManager.spawnLocation = spawnNumber;
				}
				else
				{
					GameManager.locks[keyID]=true;
					lockanim.Play("lockUnlock"); 
					starttimer=true;
				}

			}
			else if (allowNext && Input.GetButtonDown (activationButton) && GameManager.key[keyID] ==false)
			{
				bubbleanim.Play("speechBubble_lock");
			}
			if (starttimer)
			{
				time -= Time.deltaTime;
				if(time < 0)
				{
					starttimer=false;
				}
			}
			if(time < 0 && allowNext && Input.GetButtonDown (activationButton))
			{
				Application.LoadLevel(levelNumber);
				GameManager.spawnLocation = spawnNumber;
			}

		}


	}
}
