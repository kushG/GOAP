using UnityEngine;
using System.Collections;

public class PickClueC : Action {
	
	private bool cluePicked = false;
	
	public PickClueC(){
		addPreconditions ("Clue C Resolved", false);
		addEffects ("picked Clue C", true);
	}

	public override bool requiresInRange (){
		target = GameObject.Find("Clue C");
		return true;
	}
	
	public override bool performAction ()
	{
		cluePicked = true;
		isDone = true;
		return true;
	}
}
