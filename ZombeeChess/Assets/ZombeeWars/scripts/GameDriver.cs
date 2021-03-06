﻿using UnityEngine;
using System.Collections;

//make commands and directives to units (birth, make command stay or attack) 
// logik of game
/* manadger of game
1) start
2) random pass first step
3) event select unit + event select way = unit on desk
4) event unit finished his step on desk
5) other all units making his steps.
6) when last unit finished his action,
  pass step to opponent (last unit send to GameM about his finish)
     
*/
public class GameDriver : MonoBehaviour {

	public bib.UTag NewStep=bib.UTag.isNeutral;
	public bib.UTag CurrentStep=bib.UTag.isNeutral;
	public int RoundStep=0;
	bib.IconUnit storageWhiteUnit=bib.IconUnit.SoliderZiro;
	bib.IconUnit storageBlackUnit=bib.IconUnit.SoliderZiro;
	bib.WayNames storageWhiteWay=bib.WayNames.wayZiro;
	bib.WayNames storageBlackWay=bib.WayNames.wayZiro;
	bib.IconUnit storageCurrentUnit;
	bib.WayNames storageCurrentWay;

	#region random first step and gamer get a step
	// random change first player
	// gamer get a step - (put his unit to desk and unit do the step and give step to opponent)
	private bib.UTag FirstPlayer;
	void firstStep()
	{
		int IntStep=(int)Random.Range(0,2);
		switch (IntStep)
		{
		case 0: NewStep=bib.UTag.White; break;
		case 1: NewStep=bib.UTag.Black; break;		
		default: break;
		}
		FirstPlayer=NewStep;
	}	
	#endregion 

	//-----------------------
	void getStep ()
	{	
		switch (CurrentStep) {
		case bib.UTag.White: 
			if(storageWhiteUnit!=bib.IconUnit.SoliderZiro &&
				storageWhiteWay!=bib.WayNames.wayZiro){
		    		storageCurrentUnit=storageWhiteUnit;
					storageCurrentWay=storageWhiteWay;
					putUnitOnDesk();
				}; break;
		case bib.UTag.Black: 
			if(storageBlackUnit!=bib.IconUnit.SoliderZiro &&
				storageBlackWay!=bib.WayNames.wayZiro){
					storageCurrentUnit=storageBlackUnit;
					storageCurrentWay=storageBlackWay;
					putUnitOnDesk();
			}; break;
		default: Debug.Log(CurrentStep +" put your zombe on desk");
		break;
		}
		 // pick your unit 
		unitDoStep(); // wait walking or walking and attack our unit
		otherOurUnitWalking();
	}
	//-----------------------

	#region putUnitOnDesk()
	void putUnitOnDesk()
	{
		
	}
	public void getWay()
	{
		
	}
	public void getUClases()
	{

	}
	#endregion
	void unitDoStep()
	{
		Debug.Log("Your unit " + CurrentStep + "  walked ");
	}
	void otherOurUnitWalking()
	{
		Debug.Log("Your other units " + CurrentStep + "  walked ");
	}

	void eventStepChanged() //  the event pass step to opponent
	{
		if(CurrentStep!=NewStep)
		{
			CurrentStep=NewStep;
			if (FirstPlayer==CurrentStep) 
			{
				RoundStep++;
				Debug.Log("Raund "+RoundStep);
			}
			getStep();
		}
	}
	void giveStepToOpponent() // this use after otherOurUnitWalking()
	{
		if(Input.GetKeyDown(KeyCode.W)) // looking at finish action last unit
		{
			switch (CurrentStep)
			{
			case bib.UTag.White: NewStep=bib.UTag.Black; break;
			case bib.UTag.Black: NewStep=bib.UTag.White; break;
			default: break;
		    }
		}
	}

	#region CopyPaste
  /*




     Debug.Log("round "+ RoundStep);
 * */

	#endregion

	// Use this for initialization
	void Start () {
		//gameObject.tag = bib.tagGameDriver;
		firstStep();
	}
	
	// Update is called once per frame
	void Update () {		
		eventStepChanged();
		giveStepToOpponent();
	}
}
//drive events in raund