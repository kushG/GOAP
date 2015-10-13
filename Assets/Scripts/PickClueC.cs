using UnityEngine;
using System.Collections;

public class PickClueC : Action {
	
	private bool cluePicked = false;
	
	public PickClueC(){
		Preconditions.Add ("Clue C Resolved", false);
		Effects.Add ("picked Clue C", true);
	}
	
	public override bool performAction ()
	{
		cluePicked = true;
		return true;
	}
}
