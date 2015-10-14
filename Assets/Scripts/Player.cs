using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int actionPoints = 2;
	public float speed = 1.0f;
	public bool movePlayer = true;
	public Action targetAction;
	public bool playerMoved = false;

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

	void update(){
		if(movePlayer){
			transform.position = Vector3.MoveTowards(transform.position, targetAction.target.transform.position, speed * Time.deltaTime);
			if(transform.position == targetAction.target.transform.position){
				targetAction.inRange = true;
				playerMoved = true;
				movePlayer = false;
			}
		}
	}

	public void addtoCurrentWorldState(string key, object value){
		currentStateInWorld.Add(new KeyValuePair<string, object>(key, value));
	}

	public bool movePlayerTowardsClue(){
		return playerMoved;
	}
		                    
}
