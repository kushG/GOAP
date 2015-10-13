using UnityEngine;
using System.Collections;

public class PickClueA : Action {

	private bool cluePicked = false;

	public PickClueA(){
		addPreconditions ("Clue A Resolved", false);
		addEffects ("picked Clue A", true);
	}

	public override bool requiresInRange (){
		target = GameObject.Find("Clue A");
		return true;
	}
	
	public override bool performAction ()
	{
		cluePicked = true;
		isDone = true;
		return true;
	}
}
