using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int actionPoints = 2;
	public float speed = 1.0f;

	public HashSet<KeyValuePair<string, object>> currentStateInWorld;

	public void addtoCurrentWorldState(string key, object value){
		currentStateInWorld.Add(new KeyValuePair<string, object>(key, value));
	}
		                    
}
