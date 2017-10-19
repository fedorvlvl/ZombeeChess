using UnityEngine;
using System.Collections;

//make commands and directives to units (birth, make command stay or attack) 
// logik of game
public class GameAI : MonoBehaviour {
	
	public bib.UTag NewStep=bib.UTag.isNeutral;
	public bib.UTag Step=bib.UTag.isNeutral;
	public int RoundStep=0;

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
	void eventStepChanged() //  
	{
		if(Step!=NewStep)
		{
			Step=NewStep;
			if (FirstPlayer==Step) 
			{
				RoundStep++;
				Debug.Log("Round "+RoundStep);
			}
			getStep();
		}
	}
	//-----------------------
	void getStep()
	{
		putUnitOnDesk(); // pick yuor unit 
		unitDoStep(); // wait walking or walking and attack our unit
		otherOurUnitWalking();
	}
	//-----------------------
	#endregion
	#region putUnitOnDesk()
	void putUnitOnDesk()
	{
		getUClases(); 
		getWay();
		Debug.Log("You puted your unit " + Step + " on desk");
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
		Debug.Log("Your unit " + Step + "  walked ");
	}
	void otherOurUnitWalking()
	{
		Debug.Log("Your other units " + Step + "  walked ");
	}
	void giveStepToOpponent() // this use after otherOurUnitWalking()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			switch (Step)
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
		firstStep();
	}
	
	// Update is called once per frame
	void Update () {
		eventStepChanged();
		giveStepToOpponent();
	}
}
//drive events in raund