using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSM {

	// Maintain a stack to keep track of currernt state
	public Stack<string> fsmStack = new Stack<string>();

	public void pushFSM(string state){
		fsmStack.Push(state);
	}

	public void popFSM(){
		fsmStack.Pop();
	}
}
