using UnityEngine;
using System.Collections;

public class SolveBMethodC : Action {
	
	private bool clueBSolved = false;
	
	public SolveBMethodC(){
		Preconditions.Add ("picked Clue B", false);
		Effects.Add ("Clue B Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueBSolved = true;
		return true;
	}
}
