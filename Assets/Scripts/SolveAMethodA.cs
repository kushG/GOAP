using UnityEngine;
using System.Collections;

public class SolveAMethodA : Action {
	
	private bool clueASolved = false;

	public SolveAMethodA(){
		cost = 1.0f;
		addPreconditions ("picked Clue A", true);
		addEffects ("Clue A Resolved", true);
		addEffects ("Good Ending", true);
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
