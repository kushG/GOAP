using UnityEngine;
using System.Collections;

public class PickClueB : Action {
	
	private bool cluePicked = false;
	
	public PickClueB(){
		Preconditions.Add ("Clue B Resolved", false);
		Effects.Add ("picked Clue B", true);
	}
	
	public override bool performAction ()
	{
		cluePicked = true;
		return true;
	}
}
