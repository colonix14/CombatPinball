using UnityEngine;
using System.Collections;

public class BallBlock : MonoBehaviour {

	static public bool ballInsideBoard = false;
	public GameObject ballBlock;

	void OnTriggerEnter(Collider other){
		// When the trigger is hit by something
		// Check to see if it's the Ball
		if (other.gameObject.tag == "Ball") {
			
		}
	}


}
