using UnityEngine;
using System.Collections;

public interface FSMState {

	void update(FiniteStateMachine fsm, GameObject gameobject);	           
}
