using UnityEngine;
using System.Collections;

public class SolveCMethodC : Action {

	private bool clueCSolved = false;
	
	public SolveCMethodC(){
		cost = 1.0f;
		addPreconditions ("picked Clue C", true);
		addEffects ("Clue C Resolved", true);
		addEffects ("Good Ending", true);
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
