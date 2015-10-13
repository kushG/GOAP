using UnityEngine;
using System.Collections;

public class SolveBMethodA : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodA(){
		cost = 3.0f;
		addPreconditions ("picked Clue B", true);
		addEffects ("Clue B Resolved", true);
	}

	public override bool requiresInRange (){
		return false;
	}

	public override bool performAction ()
	{
		clueBSolved = true;
		return true;
	}
}
