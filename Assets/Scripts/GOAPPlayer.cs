using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GOAPPlayer : MonoBehaviour {

	FSM fsm;

	private HashSet<Action> availableActions;
	private Queue<Action> currentActions;
	
	private GoapPlanner planner;
	private Player player;

	public void Start(){

		fsm = new FSM();
		availableActions = new HashSet<Action>();
		currentActions = new Queue<Action>();
		planner = new GoapPlanner();

		if(fsm.fsmStack.Count <= 0){
			fsm.pushFSM("Idle");
		}
		player = gameObject.GetComponent<Player>();

		loadActions();
		IdleState();

	}

	public void Update(){
		if(fsm.fsmStack.Count <= null){
			fsm.pushFSM("Idle");
		}

		switch(fsm.fsmStack.Peek()){
			case "Idle": IdleState();
				break;
			case "MoveTowardsClue" : MoveTowardsClueState();
				break;
			case "PerformAction" : PerformActionState();
				break;
			case null : IdleState();
				break;
		    default : IdleState();
				break;
		}
	}


	public void addAction(Action a){
		availableActions.Add (a);
	}
	
	
	public void removeAction(Action action){
		availableActions.Remove (action);
	}
	
	private bool hasActionPlan(){
		return currentActions.Count > 0;
	}


	public void loadActions(){
		Action[] actions = gameObject.GetComponents<Action>();
		foreach(Action a in actions){
			availableActions.Add(a);
		}
	}

	/// <summary>
	/// Identifies a plan of action
	/// </summary>
	public void IdleState(){

		if(fsm.fsmStack.Peek () == "Idle"){
			HashSet<KeyValuePair<string,object>> worldState = gameObject.GetComponent<Player>().currentStateInWorld;
			HashSet<KeyValuePair<string,object>> goal = gameObject.GetComponent<Player>().goal;
						
			//Plan
			Queue<Action> plan = planner.plan (gameObject, availableActions, worldState, goal);
			if(plan !=null){
				currentActions = plan;
				fsm.popFSM();
				fsm.pushFSM("PerformAction");
			}
			else{
				Debug.Log ("plan failed");
				fsm.popFSM();
				fsm.pushFSM("idle");
			}
		}

	}

	/// <summary>
	/// Moves player towards the clue if needed.
	/// </summary>
	public void MoveTowardsClueState(){

		if(fsm.fsmStack.Peek() == "MoveTowardsClue"){
			Action action = currentActions.Peek();
			if(action.requiresInRange() && action.target == null){
				Debug.Log("<color=red>Fatal error:</color> Action requires a target but has none. Planning failed.");
				fsm.popFSM(); // move
				fsm.popFSM(); // perform
				fsm.pushFSM("Idle");
				return;
			}

			if(movePlayerTowardsClue(action)){
				fsm.popFSM();
			}
		}

	}

	public bool movePlayerTowardsClue(Action action){
		transform.position = Vector3.MoveTowards(transform.position, action.target.transform.position, player.speed * Time.deltaTime);
		action.inRange = true;
		return true;
	}

	/// <summary>
	/// Performs the action
	/// </summary>
	public void PerformActionState(){
		if(fsm.fsmStack.Peek() == "PerformAction"){
			if(!hasActionPlan()){
				// no actions to perform
				Debug.Log("<color=red>Done actions</color>");
				fsm.popFSM();
				fsm.pushFSM("Idle");
				return;
			}
			
			Action action = currentActions.Peek();
			if ( action.isDone ) {
				// the action is done. Remove it so we can perform the next one
				currentActions.Dequeue();
			}
			
			if (hasActionPlan()) {
				// perform the next action
				action = currentActions.Peek();
				bool inRange = action.requiresInRange() ? action.isInRange() : true;
				
				if ( inRange ) {
					// we are in range, so perform the action
					bool success = action.performAction();
					
					if (!success) {
						// action failed, we need to plan again
						fsm.popFSM();
						fsm.pushFSM("Idle");
					}
				} else {
					// we need to move there first
					// push moveTo state
					fsm.pushFSM("MoveTowardsClue");
				}
				
			} else {
				// no actions left, move to Plan state
				fsm.popFSM();
				fsm.pushFSM("Idle");
			}
		}
	}
}
