using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Action : MonoBehaviour {

	// Object on which action is performed. Required while movetowards state
	public GameObject target;

	//cost for performing a action
	public float cost = 1f;

	private HashSet<KeyValuePair<string, object>> preconditions;
	private HashSet<KeyValuePair<string, object>> effects;

	public bool inRange = false;

	// returns true if action is done
	public bool isDone = false;

	public Action(){
		preconditions = new HashSet<KeyValuePair<string, object>>();
		effects = new HashSet<KeyValuePair<string, object>>();
	}


	// Return true if an action has been performed
	public abstract bool performAction();

	// check required to verify if player needs to move toweards the object to perform action.
	public abstract bool requiresInRange ();

	public bool isInRange(){
		return inRange;
	}

	public void addPreconditions(string key, object value){
		preconditions.Add(new KeyValuePair<string, object>(key, value));
	}

	public void removePreconditions(string key){
		foreach(KeyValuePair<string, object> kvp in preconditions){
			if(kvp.Key.Equals(key)){
				preconditions.Remove(kvp);
			}
		}
	}

	public void addEffects(string key, object value){
		effects.Add(new KeyValuePair<string, object >(key, value));
	}

	public void removeEffects(string key){
		foreach(KeyValuePair<string, object> kvp in effects){
			if(kvp.Key.Equals(key)){
				effects.Remove(kvp);
			}
		}
	}

	public HashSet<KeyValuePair<string, object>> Preconditions {
		get {
			return preconditions;
		}
	}
	
	public HashSet<KeyValuePair<string, object>> Effects {
		get {
			return effects;
		}
	}

}
