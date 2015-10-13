using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoapPlayerAgent : MonoBehaviour {
/*	private FiniteStateMachine stateMachine;
	private FiniteStateMachine.FSMState idle;
	private FiniteStateMachine.FSMState moveTowardsClue;
	private FiniteStateMachine.FSMState performAction;

	private HashSet<Action> availableActions;
	private Queue<Action> currentAcions;

	private GoapPlanner planner;

	void Start(){
		stateMachine = new FiniteStateMachine ();
		availableActions = new HashSet<Action> ();
		currentAcions = new HashSet<Action> ();
		planner = new GoapPlanner ();
		createIdleState ();
		createMoveState ();
		createPerformActionState ();
		stateMachine.pushState (idle);
		loadActions ();
	}

    void Update(){
		stateMachine.Update (this.gameObject);
	}


	public void addAction(Action a){
		availableActions.Add (a);
	}


	public void removeAction(Action action){
		availableActions.Remove (action);
	}

	private bool hasActionPlan(){
		return currentAcions.Count;
	}

	private void createIdleState(){
		idle = (fsm, gameObject) => {

			// get the world state and the goal we want to plan for
			HashSet<KeyValuePair<string,object>> worldState = gameObject.GetComponent<Player>().currentStateInWorld;
			HashSet<KeyValuePair<string,object>> goal = gameObject.GetComponent<Player>().goal;


			//Plan
			Queue<Action> plan = planner.plan (gameObject, availableActions, worldstate, goal);
			if(plan !=null){
				currentAcions = plan;
				fsm.popState();
				fsm.pushState(performAction);
			}
			else{
				Debug.Log ("plan failed");
				fsm.popState();
				fsm.pushState(idle);
			}

		};
	}

	private void createMoveState(){
	//TODO
		moveTowardsClue = (fsm, gameObject) => {

		};
	}

	private void createPerformActionState(){
		if(!hasActionPlan){
			// no actions to perform
			Debug.Log("<color=red>Done actions</color>");
			fsm.popState();
			fsm.pushState(idle);
			dataProvider.actionsFinished();
			return;
		}
		
		GoapAction action = currentActions.Peek();
		if ( action.isDone() ) {
			// the action is done. Remove it so we can perform the next one
			currentActions.Dequeue();
		}
		
		if (hasActionPlan()) {
			// perform the next action
			action = currentActions.Peek();
			bool inRange = action.requiresInRange() ? action.isInRange() : true;
			
			if ( inRange ) {
				// we are in range, so perform the action
				bool success = action.perform(gameObj);
				
				if (!success) {
					// action failed, we need to plan again
					fsm.popState();
					fsm.pushState(idleState);
					dataProvider.planAborted(action);
				}
			} else {
				// we need to move there first
				// push moveTo state
				fsm.pushState(moveToState);
			}
			
		} else {
			// no actions left, move to Plan state
			fsm.popState();
			fsm.pushState(idleState);
			dataProvider.actionsFinished();
		}

	}

*/
}

