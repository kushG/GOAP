using UnityEngine;
using System.Collections;

public class SolveBMethodB : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodB(){
		Preconditions.Add ("picked Clue A", false);
		Effects.Add ("Clue A Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueBSolved = true;
		return true;
	}
}
