using UnityEngine;
using System.Collections;

public class SolveBMethodC : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodC(){
		cost = 2.0f;
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
