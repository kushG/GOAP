using UnityEngine;
using System.Collections;

public class SolveCMethodA : Action {
	
	private bool clueCSolved = false;
	
	public SolveCMethodA(){
		cost = 2.0f;
		addPreconditions ("picked Clue C", true);
		addEffects ("Clue C Resolved", true);
	}

	public override bool requiresInRange (){
		return false;
	}
	
	public override bool performAction ()
	{
		clueCSolved = true;
		return true;
	}
}
