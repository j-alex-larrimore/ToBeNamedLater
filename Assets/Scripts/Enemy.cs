using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public int speed;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void FixedUpdate(){
		rigidBody.AddForce (new Vector2 (speed, 0));
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "LeftBoundary") {
			TurnRight ();
		}else if(other.tag == "RightBoundary"){
			TurnLeft ();
		}
	}

	private void TurnLeft(){
		speed = Mathf.Abs (speed) * -1;
	}

	private void TurnRight(){
		speed = Mathf.Abs (speed);
	}

}
