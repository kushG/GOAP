using UnityEngine;
using System.Collections;

public class PickClueA : Action {

	private bool cluePicked = false;

	public PickClueA(){
		Preconditions.Add ("Clue A Resolved", false);
		Effects.Add ("picked Clue A", true);
	}
	
	public override bool performAction ()
	{
		cluePicked = true;
		return true;
	}
}
