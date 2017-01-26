using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	//starting level
	public int level = 1;

	//overall game mechanics
	public static int spawnLocation=0;
	//disabling movement
	public static bool disableMovement =false;
	//Currently Reading
	public static bool isReading = false;
	//Currently climbing
	public static bool isClimbing = false;
	//Currently swimming
	public static bool isSwimming = false;
	//Cutscene in Action
	public static bool onCutscene = false;
	
	//inventory
	public static bool inventory=false;
	public static List <Sprite> items = new List<Sprite>();

	/*leaf positions
	 * 0= starting house mainfloor
	 * 1= on top of first house
	 * 2= church top
	 */
	public static bool[] metalLeaves = new bool[15]; 
	/*keys
	 * 0= First House
	 * 1= Alberts House
	 * 2= Church Key
	 */
	public static bool[] key = new bool[5];

	//applies to same numbers as key
	public static bool[] locks = new bool[5];

	/* Gemstones
	 * 0-Alberts House
	 * 1-Church
	 * 2-Graveyard
	 */
	public static bool[] gems = new bool[5];

	//Michaels House cabinet
	public static bool cabinetOpen =false;
	//Alberts House cabinet
	public static bool paintingOpen=false;

	//church
	public static bool leverStatus=false;

	//churchTreasureRoom
	public static bool chestOpen= false;

	//fatherjohn
	public static bool secretwall=false;
	public static bool alreadyEntered=false;

	void Awake() 
	{

		Application.LoadLevel (level);

		//loop for leaves and keys , FIX THIS
		/*
		for (int i=0; i < 15; i++)
		{
			metalLeaves[i] = true;
		}
		for (int i=0; i < 5; i++)
		{
			key[i] = true;
		}
		*/
	}

}
