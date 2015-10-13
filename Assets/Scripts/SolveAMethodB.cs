using UnityEngine;
using System.Collections;

public class SolveAMethodB : Action {
	
	private bool clueASolved = false;
	
	public SolveAMethodB(){
		Preconditions.Add ("picked Clue A", false);
		Effects.Add ("Clue A Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueASolved = true;
		return true;
	}
}
