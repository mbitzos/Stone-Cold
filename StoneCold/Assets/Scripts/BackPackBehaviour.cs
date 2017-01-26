using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackPackBehaviour : MonoBehaviour 
{
	public Sprite[] sprites = new Sprite[8];
	public GameObject[] position =new GameObject[4];
	private SpriteRenderer[] newSprites = new SpriteRenderer[8]; 
	private int positionNumber;
	void Awake()
	{
		for(int i =0; i < 4 ;i++)
		{
			//getting the sprite renders of each item slot
			newSprites[i] = position[i].GetComponent<SpriteRenderer>();
		}
	}

	void Update () 
	{

		//displaying all the items in the list
		if(GameManager.inventory==true)
		{
			GameManager.inventory=false;
			for(int i =0;i <GameManager.items.Count; i++)
			{
				newSprites[i].sprite = GameManager.items[i];
			}
		}

	}
}
