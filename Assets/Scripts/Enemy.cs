using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float movementSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	
	}

	void Move () {
		Vector3 tempPos = pos;
		tempPos.x -= movementSpeed * Time.deltaTime;
		pos = tempPos;
	}

	public Vector3 pos {
		get {
			return(this.transform.position);
		}
		set{
			this.transform.position = value;
		}
	}
}
