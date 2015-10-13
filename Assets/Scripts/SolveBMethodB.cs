using UnityEngine;
using System.Collections;

public class SolveBMethodB : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodB(){
		cost = 1.0f;
		addPreconditions ("picked Clue A", true);
		addEffects ("Clue A Resolved", true);
		addEffects("Good Ending", true);
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
