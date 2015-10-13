using UnityEngine;
using System.Collections;

public class SolveAMethodB : Action {
	
	private bool clueASolved = false;
	
	public SolveAMethodB(){
		cost = 2.0f;
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
