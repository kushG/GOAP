using UnityEngine;
using System.Collections;

public class SolveAMethodC: Action {
	
	private bool clueASolved = false;
	
	public SolveAMethodC(){
		cost = 3.0f;
		addPreconditions ("picked Clue A", true);
		addEffects ("Clue A Resolved", true);
	}

	public override bool requiresInRange (){
		return false;
	}
	
	public override bool performAction ()
	{
		clueASolved = true;
		return true;
	}
}
