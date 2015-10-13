using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoapPlanner : MonoBehaviour {

	public bool plan(GameObject player, HashSet<Action> availableActions, HashSet<KeyValuePair<string, object>> worldstate, HashSet<KeyValuePair<string, object>> goal){
		foreach (Action action in availableActions) {
			// create a tree to keep track of sequence of actions
			Node start = new Node(0, worldstate, action);

			List<Node> children = new List<Node>();

			/* Tree - Find a cheapest route till the goal.
			 * Traverse untill goal state is reached
			 * At each node update current state with Effects of previous/Parent Node.
			*/

		}
		
	}

	/// <summary>
	/// Traverse the tree from node provided. Runs Recursively
	/// </summary>
	/// <param name="parent">Parent Node.</param>
	/// <param name="goal">Goal state.</param>
	/// <param name="availableActions">Available actions.</param>
	/// <param name="children">Children Nodes.</param>
	public void Traverse(Node parent, HashSet<KeyValuePair<string, object>> goal, List<Action> availableActions, List<Node> children )
	{
		bool foundOne = false;

		// check if current player state matches with preconditions of actions
		foreach (Action action in availableActions) {
			// if action's preconditions are present in parent.state
			if(checkifPresentInState(action.Preconditions, parent.state)){
				// Add parent's effects to currentstate of player
				HashSet<KeyValuePair<string, object>> currentstate = addState(parent.state, action.Effects);


				Node node = new Node(parent, parent.cost + action.cost, currentstate, action);

				if (checkifPresentInState(goal, currentstate)) {
					// we found a solution!
					children.Add(node);
					foundOne = true;
				} else {
					// not at a solution yet, so test all the remaining actions and branch out the tree
					HashSet<GoapAction> subset = actionSubset(availableActions, action);
					bool found = Traverse(node, goal, subset, children);
					if (found)
						foundOne = true;
				}
			}
		}
		return foundOne;
	}

	/// <summary>
	/// Checks if keyvaluepair of state A present in state B
	/// </summary>
	/// <param name="stateA">State a.</param>
	/// <param name="stateB">State b.</param>
	public bool checkifPresentInState(HashSet<KeyValuePair<string, object>> stateA, HashSet<KeyValuePair<string, object>> stateB){
		bool allPresent = true;
		foreach (KeyValuePair<string,object> a in stateA) {
			bool match = false;
			foreach (KeyValuePair<string,object> b in stateB) {
				if (b.Equals(a)) {
					match = true;
					break;
				}
			}
			if (!match)
				allPresent = false;
		}
		return allPresent;
	}

	/// <summary>
	/// Adds the action effect to currentstate
	/// </summary>
	/// <returns>The updated current state.</returns>
	/// <param name="currentState">Current state.</param>
	/// <param name="effects">Effects.</param>
    private HashSet<KeyValuePair<string,object>> addState(HashSet<KeyValuePair<string,object>> currentState, HashSet<KeyValuePair<string,object>> effects) {
		HashSet<KeyValuePair<string,object>> state = new HashSet<KeyValuePair<string,object>> ();
		// copy the KVPs over as new objects
		foreach (KeyValuePair<string,object> s in currentState) {
			state.Add(new KeyValuePair<string, object>(s.Key,s.Value));
		}
		
		foreach (KeyValuePair<string,object> change in effects) {
			// if the key exists in the current state, update the Value
			bool exists = false;
			
			foreach (KeyValuePair<string,object> s in state) {
				if (s.Equals(change)) {
					exists = true;
					break;
				}
			}
			
			if (exists) {
				state.RemoveWhere( (KeyValuePair<string,object> kvp) => { return kvp.Key.Equals (change.Key); } );
				KeyValuePair<string, object> updated = new KeyValuePair<string, object>(change.Key,change.Value);
				state.Add(updated);
			}
			// if it does not exist in the current state, add it
			else {
				state.Add(new KeyValuePair<string, object>(change.Key,change.Value));
			}
		}
		return state;
	} 

	/// <summary>
	/// Creates subset of actions excluding current action
	/// </summary>
	/// <returns>The subset.</returns>
	/// <param name="actions">Actions.</param>
	/// <param name="removeMe">Remove me.</param>
	private HashSet<Action> actionSubset(HashSet<Action> actions, Action removeMe) {
		HashSet<Action> subset = new HashSet<Action> ();
		foreach (Action a in actions) {
			if (!a.Equals(removeMe))
				subset.Add(a);
		}
		return subset;
	}

	class Node{
		public Node parent;
		public HashSet<KeyValuePair<string, object>> state;
		public float cost;
		public Action action;

		public Node(Node parent, float cost, HashSet<KeyValuePair<string, object>> state, Action action){
			this.state = state;
			this.cost = cost;
			this.action = action;
			this.parent = parent;
		}

	}
}
