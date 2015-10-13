using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int actionPoints = 2;
	public float speed = 1.0f;

	public HashSet<KeyValuePair<string, object>> currentStateInWorld;
	public HashSet<KeyValuePair<string, object>> goal;

	void Start(){
		currentStateInWorld = new HashSet<KeyValuePair<string, object>>();
		currentStateInWorld.Add(new KeyValuePair<string, object>("Clue A Resolved", false));
		currentStateInWorld.Add(new KeyValuePair<string, object>("Clue B Resolved", false));
		currentStateInWorld.Add(new KeyValuePair<string, object>("Clue C Resolved", false));

		goal = new HashSet<KeyValuePair<string, object>>();
		goal.Add(new KeyValuePair<string, object>("Good Ending", true));
	}

	public void addtoCurrentWorldState(string key, object value){
		currentStateInWorld.Add(new KeyValuePair<string, object>(key, value));
	}
		                    
}
