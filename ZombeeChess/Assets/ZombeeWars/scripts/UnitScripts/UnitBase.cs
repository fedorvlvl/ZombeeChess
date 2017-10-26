using UnityEngine;
using System.Collections;

public class UnitBase : MonoBehaviour {
	public bib.UTag UnitTag;
	public bib.UClases UnitClass;
	public bib.UStates currentStates=bib.UStates.wait;
	public bib.UStatus IsLast=bib.UStatus.IsnotLast;




	void unitSetup()
	{
		// set UTag;
		// set HP
		// set speed
		// instatiate unit shape from UClass
	}


	// Use this for initialization
	void Start () 
	{
		unitSetup(); 
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
		{

		}
		
	}
}
