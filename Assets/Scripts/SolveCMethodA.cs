using UnityEngine;
using System.Collections;

public class SolveCMethodA : Action {
	
	private bool clueCSolved = false;
	
	public SolveCMethodA(){
		Preconditions.Add ("picked Clue C", false);
		Effects.Add ("Clue C Resolved", true);
	}
	
	public override bool performAction ()
	{
		clueCSolved = true;
		return true;
	}
}
