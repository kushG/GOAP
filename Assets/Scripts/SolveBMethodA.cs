using UnityEngine;
using System.Collections;

public class SolveBMethodA : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodA(){
		Preconditions.Add ("picked Clue B", false);
		Effects.Add ("Clue B Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueBSolved = true;
		return true;
	}
}
