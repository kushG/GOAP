using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FiniteStateMachine {

	private Stack<FSMState> stateStack = new Stack<FSMState> ();

	public delegate void FSMState( FiniteStateMachine fsm, GameObject gameobject);

	public void Update(GameObject gameobject){
		if(stateStack.Peek() != null){
			stateStack.Invoke(this, gameobject);
		}
	}

	public void pushState(FSMState state) {
		stateStack.Push (state);
	}
	
	public void popState() {
		stateStack.Pop ();
	}

}
