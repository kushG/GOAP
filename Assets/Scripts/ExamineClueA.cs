using UnityEngine;
using System.Collections;

public class ExamineClueA : Action {

	private bool clueSolved = false;

	public ExamineClueA(){
		addPreconditions("Clue resolved", false);
		addPreconditions("has 3 Action Points", true);
		addPreconditions("has clue C", true);
		addPreconditions("is a scientist", true);
		addEffects("has clue A", true);
	}

	public void SolveClue(){
		clueSolved = true;
	}

}
