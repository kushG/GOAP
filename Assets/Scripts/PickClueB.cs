using UnityEngine;
using System.Collections;

public class PickClueB : Action {
	
	private bool cluePicked = false;
	
	public PickClueB(){
		addPreconditions ("Clue B Resolved", false);
		addEffects ("picked Clue B", true);
	}

	public override bool requiresInRange (){
		target = GameObject.Find("Clue B");
		return true;
	}

	public override bool performAction ()
	{
		cluePicked = true;
		isDone = true;
		return true;
	}
}
