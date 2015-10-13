using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Action : MonoBehaviour {

	// Character who is examining the clue(Scientist, Historian, Diplomat or Maverick)
	public GameObject character;

	//cost for performing a action
	public float cost = 1f;

	private HashSet<KeyValuePair<string, object>> preconditions;
	private HashSet<KeyValuePair<string, object>> effects;

	public bool inRange = false;


	//Move towards the clue to examine the clue
	public abstract void moveTowards();


	// Return true if an action has been performed
	public abstract bool performAction();

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
