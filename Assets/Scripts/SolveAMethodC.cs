using UnityEngine;
using System.Collections;

public class SolveAMethodC: Action {
	
	private bool clueASolved = false;
	
	public SolveAMethodC(){
		Preconditions.Add ("picked Clue A", false);
		Effects.Add ("Clue A Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueASolved = true;
		return true;
	}
}
