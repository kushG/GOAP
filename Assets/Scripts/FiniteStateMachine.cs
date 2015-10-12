using UnityEngine;
using System.Collections;

public class FiniteStateMachine : MonoBehaviour {
	public GameObject[] clues = new GameObject[3];
	public GameObject aiPlayer;
	public string state;


	public bool IdleState(){
		state = "Idle";
		movetowardsClueState();
		return true;

	}

	public bool movetowardsClueState(){
		state = "moveTowardsClue";
		float minDistance = 0;
		GameObject nearestClue;
		foreach(GameObject clue in clues){
			if(nearestClue == null){
				nearestClue = clue;
				minDistance = (clue.transform.position - aiPlayer.transform.position).magnitude;
			}
			else{
				float distance = (clue.transform.position - aiPlayer.transform.position).magnitude;
				if(distance < minDistance){
					minDistance = distance;
					nearestClue = clue;
				}
			}
		}

		return true;
	}

	public bool solveClue(){
		state = "solveClue";
		return true;

	}

}
